using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the DynamicBlockDefinition schema.
/// </summary>
public class DynamicBlockDefinition
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Definition of manifest for dynamic block to be created in runtime by workflows execution engine.
    /// </summary>
    [JsonProperty("manifest")] 
    public ManifestDescription Manifest { get; set; }

    /// <summary>
    /// Code to be executed in run(...) method of block that will be dynamically created.
    /// </summary>
    [JsonProperty("code")] 
    public PythonCode Code { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="DynamicBlockDefinition"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="manifest">The manifest.</param>
    /// <param name="code">The code.</param>
    public DynamicBlockDefinition(string type, ManifestDescription manifest, PythonCode code)
    {
        this.Type = type;
        this.Manifest = manifest;
        this.Code = code;
    }
}