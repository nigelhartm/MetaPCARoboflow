using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the MemorySinkConfiguration schema.
/// </summary>
public class MemorySinkConfiguration
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the results_buffer_size.
    /// </summary>
    [JsonProperty("results_buffer_size")] 
    public int Results_Buffer_Size { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="MemorySinkConfiguration"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    public MemorySinkConfiguration(string type)
    {
        this.Type = type;
    }
}