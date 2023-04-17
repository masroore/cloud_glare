using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using CefSharp;
using Cookie = System.Net.Cookie;

namespace CloudGlare;

public class ProxySession
{
    private readonly ProxyNode _proxy;
    private string _host;

    public ProxySession(ProxyNode proxy, string host)
    {
        _proxy = proxy;
        _host = host;
        Headers = new Dictionary<string, string>();
        Cookies = new Dictionary<string, string>();
    }

    public string TargetUrl { get; private set; }
    public string ProxyUrl => _proxy.FullyQualifiedUrl;
    public string ProxyRawUrl => _proxy.RawUrl;
    public string ProxyId => _proxy.Id;
    public string UserAgent { get; set; }
    public List<string> UrlsCaptured { get; } = new();
    public Dictionary<string, string> Cookies { get; }
    public Dictionary<string, string> Headers { get; }

    public void SetTargetUrl(string url)
    {
        TargetUrl = url;
        _host = Helpers.GetDomainName(url);
    }

    private bool isSameDomain(string url) => string.CompareOrdinal(_host, Helpers.GetDomainName(url)) == 0;

    public string Serialize()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        //return JsonSerializer.Serialize(SerializableData(), options: options);
        return JsonSerializer.Serialize(this, options);
    }

    private void parseCookieHeader(string cookieHeader, string url)
    {
        var cookieJar = new CookieContainer();
        var uri = new Uri(url);
        cookieJar.SetCookies(uri, cookieHeader);
        if (cookieJar.Count > 0)
        {
            var cookies = cookieJar.GetCookies(uri).Cast<Cookie>();
            foreach (var cookie in cookies) Cookies[cookie.Name] = cookie.Value;
        }
    }

    public void UpdateHeaders(IRequest request)
    {
        // only allow headers for the same top-level domain
        if (!isSameDomain(request.Url)) return;

        if (UrlsCaptured.IndexOf(request.Url) == -1)
        {
            UrlsCaptured.Add(request.Url);
            UrlsCaptured.Sort();
        }

        foreach (var key in request.Headers.AllKeys) Headers[key] = request.Headers[key];

        if (request.Headers.AllKeys.Contains("User-Agent")) UserAgent = request.Headers["User-Agent"];

        if (request.Headers.AllKeys.Contains("Cookie"))
        {
            var cookieHeader = request.Headers["Cookie"];
            parseCookieHeader(cookieHeader, request.Url);
        }
    }
}