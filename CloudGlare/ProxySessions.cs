using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CloudGlare;

public class ProxySessions
{
    private string _host = string.Empty;

    public List<ProxySession> Sessions { get; } = new();

    public void SetHostFromUrl(string url)
    {
        _host = Helpers.GetDomainName(url);
    }

    public ProxySession CreateSession(ProxyNode proxy, string userAgent)
    {
        var session = new ProxySession(proxy, _host)
        {
            UserAgent = userAgent
        };
        Sessions.Add(session);
        return session;
    }

    public ProxySession? FindSession(ProxyNode proxy)
    {
        return Sessions.FirstOrDefault(sess => sess.ProxyId == proxy.Id);
    }

    public void SaveToFile(string filename)
    {
        var data = Sessions.ToDictionary(session => session.ProxyId);
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filename, json);
    }
}