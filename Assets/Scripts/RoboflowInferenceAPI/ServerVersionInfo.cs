using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Server version information.
/// 
/// Attributes:
///     name (str): Server name.
///     version (str): Server version.
///     uuid (str): Server UUID.
/// </summary>
public class ServerVersionInfo
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [JsonProperty("name")] 
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the version.
    /// </summary>
    [JsonProperty("version")] 
    public string Version { get; set; }

    /// <summary>
    /// Gets or sets the uuid.
    /// </summary>
    [JsonProperty("uuid")] 
    public string Uuid { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ServerVersionInfo"/>.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="version">The version.</param>
    /// <param name="uuid">The uuid.</param>
    public ServerVersionInfo(string name, string version, string uuid)
    {
        this.Name = name;
        this.Version = version;
        this.Uuid = uuid;
    }
}