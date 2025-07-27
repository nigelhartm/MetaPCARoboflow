using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ExecutionEngineVersions schema.
/// </summary>
public class ExecutionEngineVersions
{
    /// <summary>
    /// Gets or sets the versions.
    /// </summary>
    [JsonProperty("versions")] 
    public List<string> Versions { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ExecutionEngineVersions"/>.
    /// </summary>
    /// <param name="versions">The versions.</param>
    public ExecutionEngineVersions(List<string> versions)
    {
        this.Versions = versions;
    }
}