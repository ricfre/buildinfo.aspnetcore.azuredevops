using System.Text.Json;

namespace BuildInfo.AspNetCore.AzureDevops;

internal class BuildInfoProvider : IBuildInfoProvider
{
    private readonly Lazy<BuildInformation> _buildInformationLazy;

    public BuildInfoProvider()
    {
        _buildInformationLazy = new(ReadBuildInfo);
    }

    public BuildInformation GetBuildInfo()
    {
        return _buildInformationLazy.Value;
    }

    private static BuildInformation ReadBuildInfo()
    {
        using var fileReader = File.OpenRead("BuildInfoData/buildInfo.json");
        var buildInfo = JsonSerializer.Deserialize<BuildInformation>(fileReader);
        return buildInfo;
    }
}
