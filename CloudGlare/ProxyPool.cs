using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudGlare;

public class ProxyPool
{
    private readonly List<ProxyNode> _proxies = new();

    public int Count => _proxies.Count;

    public ProxyNode? FindProxy(string host, int port) =>
        _proxies.FirstOrDefault(node => node.Host.Equals(host) && node.Port == port);

    public ProxyPool Shuffle()
    {
        _proxies.Shuffle();
        return this;
    }

    public ProxyPool LoadFile(string filename)
    {
        var lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        foreach (var line in lines) _proxies.Add(ProxyNode.ParseLine(line));

        return this;
    }

    public IEnumerator<ProxyNode> GetEnumerator() => ((IEnumerable<ProxyNode>)_proxies).GetEnumerator();

    public List<string> RawUrls() => _proxies.Select(p => p.RawUrl).ToList();
}