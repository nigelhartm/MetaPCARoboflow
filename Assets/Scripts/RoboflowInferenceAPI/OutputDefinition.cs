using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the OutputDefinition schema.
/// </summary>
public class OutputDefinition
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [JsonProperty("name")] 
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the kind.
    /// </summary>
    [JsonProperty("kind")] 
    public List<Kind> Kind { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputDefinition"/>.
    /// </summary>
    /// <param name="name">The name.</param>
    public OutputDefinition(string name)
    {
        this.Name = name;
    }
}