using System.Collections.Generic;
using System.Threading.Tasks;
using CefSharp;

namespace CloudGlare;

public class CookieThief : ICookieVisitor
{
    private readonly List<Cookie> _cookies = new();
    private readonly TaskCompletionSource<List<Cookie>> _source = new();
    public Task<List<Cookie>> Task => _source.Task;

    public void Dispose()
    {
    }

    public bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie)
    {
        _cookies.Add(cookie);

        if (count == total - 1) _source.SetResult(_cookies);

        return true;
    }
}