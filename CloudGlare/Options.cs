using System;
using IniParser;
using IniParser.Model;

namespace CloudGlare;

public class Options
{
    public string TargetUrl { get; set; }

    public static Options Get(string configFilename)
    {
        var options = new Options();
        options.LoadFromFile(configFilename);
        return options;
    }

    public void LoadFromFile(string configFilename)
    {
        var parser = new FileIniDataParser();
        try
        {
            var data = parser.ReadFile(configFilename);
            TargetUrl = data["Main"]["TargetUrl"];
        }
        catch (Exception e)
        {
        }
    }

    public void SaveToFile(string configFilename)
    {
        var parser = new FileIniDataParser();
        var data = new IniData
        {
            ["Main"] =
            {
                ["TargetUrl"] = TargetUrl
            }
        };
        parser.WriteFile(configFilename, data);
    }
}