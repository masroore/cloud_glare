using System.Threading.Tasks;
using CefSharp;
using CefSharp.Handler;

namespace CloudGlare;

public class ResourceRequestHandlerExt : ResourceRequestHandler
{
    private readonly ProxySession _session;

    public ResourceRequestHandlerExt(ProxySession session)
    {
        _session = session;
    }


    protected override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser,
        IFrame frame, IRequest request, IRequestCallback callback)
    {
        var headers = request.Headers;
        _session.UpdateHeaders(request);

        return base.OnBeforeResourceLoad(chromiumWebBrowser, browser, frame, request, callback);
    }
}

public class BrowserRequestHandler : RequestHandler
{
    private readonly ProxyPool _pool;

    public BrowserRequestHandler(ProxyPool pool)
    {
        _pool = pool;
    }

    public ProxySession? Session { get; set; } = null;

    protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser,
        IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator,
        ref bool disableDefaultHandling)
    {
        if (Session != null) return new ResourceRequestHandlerExt(Session);
        return base.GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload,
            requestInitiator, ref disableDefaultHandling);
    }


    protected override bool OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode,
        string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
    {
        // ignore cert errors
        return true;
    }

    protected override bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame,
        IRequest request, bool userGesture, bool isRedirect)
    {
        if (!isRedirect)
            Session?.UpdateHeaders(request);

        return false;
    }

    protected override bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl,
        bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
    {
        if (!isProxy || _pool.Count <= 0) return false;
        
        var proxy = _pool.FindProxy(host, port);
        if (proxy == null)
            return false;

        Task.Run(() =>
        {
            using (callback)
            {
                callback.Continue(proxy.Username, proxy.Password);
            }
        });


        return true;
    }
}