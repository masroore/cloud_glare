using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CefSharp;
using Nager.PublicSuffix;
using Cookie = System.Net.Cookie;

namespace CloudGlare;

public static class Helpers
{
    private static readonly Random _random = new();

    public static void Shuffle<T>(this IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = _random.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    public static string GetDomainName(string url)
    {
        var cache = new FileCacheProvider(cacheTimeToLive: TimeSpan.FromDays(30));
        var rules = new WebTldRuleProvider(cacheProvider: cache);
        var parser = new DomainParser(rules);
        var info = parser.Parse(url);
        return info.RegistrableDomain.ToLowerInvariant();
    }

    public static bool IsSameDomain(string url1, string url2)
    {
        var domain1 = GetDomainName(url1);
        var domain2 = GetDomainName(url2);
        return string.Compare(domain1, domain2, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static IEnumerable<Cookie> GetAllCookies(this CookieContainer c)
    {
        var k = (Hashtable)c.GetType().GetField("m_domainTable", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(c);
        foreach (DictionaryEntry element in k)
        {
            var sl = (SortedList)element.Value.GetType()
                .GetField("m_list", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(element.Value);

            foreach (var e in sl)
            {
                var cl = (CookieCollection)((DictionaryEntry)e).Value;
                foreach (Cookie fc in cl) yield return fc;
            }
        }
    }

    public static Task LoadUrlAsync(this IWebBrowser browser, string url)
    {
        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        EventHandler<LoadingStateChangedEventArgs>? handler = null;
        handler = (sender, args) =>
        {
            //Wait for while page to finish loading not just the first frame
            if (!args.IsLoading)
            {
                browser.LoadingStateChanged -= handler;
                //Important that the continuation runs async using TaskCreationOptions.RunContinuationsAsynchronously
                tcs.TrySetResult(true);
            }
        };

        browser.LoadingStateChanged += handler;

        if (!string.IsNullOrEmpty(url))
        {
            browser.LoadUrl(url);
        }

        return tcs.Task;
    }

    public static Task LoadUrlFrameAsync(this IWebBrowser browser, string url)
    {
        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        EventHandler<FrameLoadEndEventArgs>? handler = null;
        handler = (sender, e) =>
        {
            if (e.Frame.IsMain)
            {
                browser.FrameLoadEnd -= handler;
                //Important that the continuation runs async using TaskCreationOptions.RunContinuationsAsynchronously
                tcs.TrySetResult(true);
            }
        };

        browser.FrameLoadEnd += handler;

        if (!string.IsNullOrEmpty(url))
        {
            browser.LoadUrl(url);
        }

        return tcs.Task;
    }

    public static T Pop<T>(this List<T> list, int index = 0)
    {
        if (list.Count == 0) return default(T);

        var r = list[index];
        list.RemoveAt(index);
        return r;
    }

    public static string Slugify(this string phrase)
    {
        var str = phrase.RemoveAccent().ToLower();
        // invalid chars           
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        // convert multiple spaces into one space   
        str = Regex.Replace(str, @"\s+", " ").Trim();
        // cut and trim 
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        str = Regex.Replace(str, @"\s", "-"); // hyphens   
        return str;
    }

    public static string RemoveAccent(this string txt)
    {
        byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
        return System.Text.Encoding.ASCII.GetString(bytes);
    }
}