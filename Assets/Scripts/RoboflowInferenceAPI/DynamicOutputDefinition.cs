using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the DynamicOutputDefinition schema.
/// </summary>
public class DynamicOutputDefinition
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// List representing union of kinds for defined output
    /// </summary>
    [JsonProperty("kind")] 
    public List<string> Kind { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="DynamicOutputDefinition"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    public DynamicOutputDefinition(string type)
    {
        this.Type = type;
    }
}