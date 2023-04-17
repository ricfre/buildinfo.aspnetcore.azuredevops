using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BuildInfo.AspNetCore.AzureDevops;

/// <summary>
/// Extensions for build information service registration.
/// </summary>
public static class BuildInfoProviderDependencyInjectionExtensions
{
    /// <summary>
    /// Adds a <see cref="IBuildInfoProvider"/> to the service collection.
    /// </summary>
    public static IServiceCollection AddBuildInfoServices(this IServiceCollection services)
    {
        services.TryAddSingleton<IBuildInfoProvider, BuildInfoProvider>();
        return services;
    }
}
