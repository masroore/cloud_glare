using SlugGenerator;

namespace CloudGlare;

public class ProxyNode
{
    public string Host { get; private set; }
    public int Port { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Scheme { get; private set; } = "http";

    public string FullyQualifiedUrl => $"{Scheme}://{RawUrl}";

    public string RawUrl => $"{Username}:{Password}@{Host}:{Port}";

    public string Id => $"{Host.Replace('.', ' ')} {Port}".GenerateSlug();

    public string CefCompatibleUrl => $"{Scheme}://{Host}:{Port}";

    public static ProxyNode ParseLine(string s)
    {
        var parts = s.Trim().Split(':');
        return new ProxyNode
        {
            Host = parts[0].Trim(),
            Port = int.Parse(parts[1].Trim()),
            Username = parts[2].Trim(),
            Password = parts[3].Trim(),
            Scheme = "http"
        };
    }
}