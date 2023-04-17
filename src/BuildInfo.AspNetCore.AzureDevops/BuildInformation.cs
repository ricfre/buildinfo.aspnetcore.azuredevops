namespace BuildInfo.AspNetCore.AzureDevops;

/// <summary>
/// Contains generic build information.
/// </summary>
public readonly record struct BuildInformation
{
    private static readonly string[] _mainBranchNames = { "main", "master" };

    /// <summary>
    /// The name of the branch from which the application was built.
    /// </summary>
    public string BranchName { get; init; }

    /// <summary>
    /// The git hash (full) for the commit from which the application was built.
    /// </summary>
    public string Sha { get; init; }

    /// <summary>
    /// The git hash (short) for the commit from which the application was built.
    /// </summary>
    public string ShortSha
    {
        get
        {
            // Note this is not optimal since there may be duplicates (in theory).
            // It would be better to ask git for the short value, but that is much more work.
            return Sha.Length < 7 ? Sha : Sha[..7];
        }
    }

    /// <summary>
    /// The timestamp when the application was built.
    /// </summary>
    public string BuildTimestamp { get; init; }

    /// <summary>
    /// The id of the build (technical).
    /// </summary>
    public string BuildId { get; init; }

    /// <summary>
    /// The number of the build (what humans are referring to).
    /// </summary>
    public string BuildNumber { get; init; }

    /// <summary>
    /// Full url to the build.
    /// </summary>
    public string BuildUrl { get; init; }

    /// <summary>
    /// The name of the build agent where the application was built.
    /// </summary>
    public string BuildAgentName { get; init; }
    
    /// <inheritdoc />
    public override string ToString()
    {
        var branchInfo = _mainBranchNames.Contains(BranchName) ? "" : $" @{BranchName}";
        return $"{BuildNumber}{branchInfo} [{ShortSha}]";
    }
}
