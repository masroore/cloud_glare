using System;
using System.Collections.Generic;
using Nager.PublicSuffix;

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
}