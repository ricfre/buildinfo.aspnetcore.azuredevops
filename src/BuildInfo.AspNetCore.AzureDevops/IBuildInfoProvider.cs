namespace BuildInfo.AspNetCore.AzureDevops;

/// <summary>
/// Provider for generic <see cref="BuildInformation"/>.
/// </summary>
public interface IBuildInfoProvider
{
    /// <summary>
    /// Gets the build information.
    /// </summary>
    BuildInformation GetBuildInfo();
}
