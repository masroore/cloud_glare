using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace CloudGlare.Win;

public partial class Form1 : Form
{
    private ChromiumWebBrowser _browser;
    private ProxyNode _currentProxy;
    private IEnumerator<ProxyNode> _enumerator;
    private readonly ProxyPool _proxies;
    private readonly BrowserRequestHandler _requestHandler;
    private readonly ProxySessions _sessions;
    private string _userAgent;
    private string _saveDirectory = string.Empty;
    private bool _visitingCustomUrls = false;
    private List<string> _customUrls = new();

    public Form1()
    {
        _proxies = new ProxyPool();
        _sessions = new ProxySessions();
        _requestHandler = new BrowserRequestHandler(_proxies);
        InitializeComponent();
    }

    private string getUrl()
    {
        return txtUrl.Text.Trim();
    }

    private async void createBrowser()
    {
        if (checkBrowser())
        {
            _browser.Parent = null;
            Controls.Remove(_browser);
            _browser.Dispose();
        }

        splitContainer.Panel1.Controls.Clear();
        _browser = null;

        _browser = new ChromiumWebBrowser
        {
            RequestContext = getContext(),
            RequestHandler = _requestHandler
        };
        splitContainer.Panel1.Controls.Add(_browser);
        _browser.Dock = DockStyle.Fill;

        if (_browser.IsBrowserInitialized) getUserAgent();
    }

    private bool checkBrowser()
    {
        return _browser != null;
    }

    private async void getUserAgent()
    {
        if (!string.IsNullOrEmpty(_userAgent) || !checkBrowser()) return;

        _userAgent = await _browser.GetMainFrame().EvaluateScriptAsync("navigator.userAgent;")
            .ContinueWith(
                t =>
                {
                    var result = t.Result;
                    return result.Success ? (string)result.Result : string.Empty;
                });

        txtUserAgent.Text = _userAgent;
    }

    private IRequestContext getContext()
    {
        if (!_visitingCustomUrls && _currentProxy == null)
            getNextProxy();

        var builder = RequestContext
            .Configure();

        if (!_visitingCustomUrls && _currentProxy != null)
            builder = builder
                .WithProxyServer(_currentProxy.Host, _currentProxy.Port)
                .WithCachePath(Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "CefSharp\\" + _currentProxy.Id));

        var requestContext = builder.Create();

        return requestContext;
    }

    private void getNextProxy()
    {
        _currentProxy = null;

        if (_proxies.Count == 0) return;

        if (_enumerator == null || !_enumerator.MoveNext())
            return;
        _currentProxy = _enumerator.Current;
        updateProxyLabel();
        getUserAgent();
        _requestHandler.Session = _sessions.CreateSession(_currentProxy, _userAgent);
    }

    private void btnLoadProxies_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            _proxies.LoadFile(openFileDialog.FileName).Shuffle();
            _enumerator = _proxies.GetEnumerator();
            txtProxies.Text = string.Join("\r\n", _proxies.RawUrls());
            getNextProxy();
        }
    }

    private void updateProxyLabel()
    {
        lblProxy.Text = _currentProxy == null ? string.Empty : _currentProxy.CefCompatibleUrl;
    }

    private void btnSwitchNextProxy_Click(object sender, EventArgs e)
    {
        getNextProxy();
        updateProxyLabel();
        if (_currentProxy == null || !checkBrowser()) return;

        Cef.UIThreadTaskFactory.StartNew(delegate
        {
            var rc = _browser.GetBrowser().GetHost().RequestContext;
            var proxy_config = new Dictionary<string, object>
            {
                ["mode"] = "fixed_servers",
                ["server"] = _currentProxy.CefCompatibleUrl
            };

            var success = rc.SetPreference("proxy", proxy_config, out var errorMessage);
            if (!success) MessageBox.Show(errorMessage);

            /*
            if (!rc.CanSetPreference("proxy"))
            {
                //Unable to set proxy, if you set proxy via command line args it cannot be modified.
            }

            success = rc.SetProxy(_currentProxy.Host, _currentProxy.Port, out errorMessage);
            if (!success) MessageBox.Show(errorMessage);
            */
        });
    }

    private void btnLoadUrl_Click(object sender, EventArgs e)
    {
        //if (_browser == null)
        createBrowser();

        visitUrl();
    }

    private async void visitUrl(string? url = null)
    {
        var targetUrl = url ?? getUrl();

        if (!_visitingCustomUrls)
        {
            _sessions.SetHostFromUrl(targetUrl);
            _sessions.FindSession(_currentProxy)?.SetTargetUrl(targetUrl);
        }

        //_browser.LoadUrl(targetUrl);
        await _browser.LoadUrlFrameAsync(targetUrl);
        await _browser.WaitForInitialLoadAsync();
        Thread.Sleep(1000);

        if (!_visitingCustomUrls)
        {
            fetchCookies(targetUrl);
            getUserAgent();
            populateSessionWidgets();
        }
        else
        {
            await saveBrowserSource(url);
        }
    }

    private async Task saveBrowserSource(string url)
    {
        if (!string.IsNullOrEmpty(_saveDirectory) && chkAutoSavePage.Checked)
        {
            var uri = new Uri(url);
            var filename = DateTime.Now.ToString("yy-MM-dd_hh-mm-ss_") + uri.Segments.Last().Slugify();
            filename = Path.ChangeExtension(filename, ".html");
            filename = Path.Combine(_saveDirectory, filename);

            var source = await _browser.GetSourceAsync();
            File.WriteAllText(filename, source);
        }
    }

    private async void fetchCookies(string? targetUrl = null)
    {
        targetUrl ??= getUrl();
        var session = _sessions.FindSession(_currentProxy);
        if (session == null) return;

        var cookieManager = Cef.GetGlobalCookieManager();
        var visitor = new CookieThief();
        cookieManager.VisitUrlCookies(targetUrl, true, visitor);
        //cookieManager.VisitAllCookies(visitor);
        var cookies = await visitor.Task;
        foreach (var cookie in cookies)
            //session.Cookies.Add(cookie.Name, cookie.Value);
            session.Cookies[cookie.Name] = cookie.Value;
    }

    private void populateSessionWidgets()
    {
        var session = _sessions.FindSession(_currentProxy);
        if (session == null) return;

        lvwHeaders.Items.Clear();
        foreach (var kvp in session.Headers)
            addListViewItems(lvwHeaders, kvp.Key, kvp.Value);

        lvwCookies.Items.Clear();
        foreach (var kvp in session.Cookies)
            addListViewItems(lvwCookies, kvp.Key, kvp.Value);
    }

    private void addListViewItems(ListView control, string label, string value)
    {
        var lvi = new ListViewItem
        {
            Text = label
        };
        lvi.SubItems.Add(value);
        control.Items.Add(lvi);
    }

    private void btnEvalUserAgent_Click(object sender, EventArgs e)
    {
        if (_browser != null)
            getUserAgent();
    }

    private void btnCookies_Click(object sender, EventArgs e)
    {
        fetchCookies();
        populateSessionWidgets();
    }

    private void btnSaveSessions_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog(this) == DialogResult.OK) _sessions.SaveToFile(saveFileDialog.FileName);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        txtUrl.Text = Options.Get("cloudglare.conf").TargetUrl;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        var options = new Options
        {
            TargetUrl = getUrl()
        };
        options.SaveToFile("cloudglare.conf");
    }

    private void btnCycleProxies_Click(object sender, EventArgs e)
    {
        if (_proxies.Count < 1) return;

        _enumerator = _proxies.GetEnumerator();
        _currentProxy = _enumerator.Current;

        updateTimerInterval();
        timer.Enabled = true;
    }

    private void trkIntervalSeconds_Scroll(object sender, EventArgs e)
    {
        updateTimerInterval();
    }

    private void updateTimerInterval()
    {
        timer.Interval = trkIntervalSeconds.Value * 1000;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (_visitingCustomUrls)
        {
            var url = getCustomUrl();
            if (string.IsNullOrEmpty(url))
            {
                timer.Enabled = false;
                return;
            }

            visitUrl(url);
            return;
        }

        getNextProxy();

        if (_currentProxy == null)
        {
            timer.Enabled = false;
            return;
        }

        updateProxyLabel();

        createBrowser();

        visitUrl();
    }

    private string? getCustomUrl() => _customUrls.Pop();

    private void trkUrlsInterval_Scroll(object sender, EventArgs e) =>
        lblUrlInterval.Text = $"Interval: {trkUrlsInterval.Value} secs";

    private void btnLoadAllUrls_Click(object sender, EventArgs e)
    {
        if (chkAutoSavePage.Checked)
        {
            _saveDirectory = string.Empty;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                _saveDirectory = folderBrowserDialog.SelectedPath;

            chkAutoSavePage.Checked = !string.IsNullOrEmpty(_saveDirectory);
        }

        _customUrls.Clear();
        _customUrls.AddRange(txtUrls.Lines.Where(s => !string.IsNullOrEmpty(s)).ToList());

        createBrowser();

        _visitingCustomUrls = true;
        updateTimerInterval();
        timer.Enabled = true;
    }
}