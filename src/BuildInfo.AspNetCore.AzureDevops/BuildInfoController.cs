using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildInfo.AspNetCore.AzureDevops;

/// <summary>
/// Contains endpoints related to build information.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class BuildInfoController : ControllerBase
{
    private readonly IBuildInfoProvider _buildInfoProvider;

    /// <summary>
    /// Creates a new instance of <see cref="BuildInfoController"/>.
    /// </summary>
    public BuildInfoController(IBuildInfoProvider buildInfoProvider)
    {
        _buildInfoProvider = buildInfoProvider;
    }

    /// <summary>
    /// Gets all build information.
    /// </summary>
    /// <response code="200">The build information is successfully returned.</response>
    [ProducesResponseType(typeof(BuildInformation), StatusCodes.Status200OK)]
    [AllowAnonymous]
    [HttpGet]
    public ActionResult GetBuildInfo()
    {
        var buildInfo = _buildInfoProvider.GetBuildInfo();
        
        return Ok(buildInfo);
    }
}
