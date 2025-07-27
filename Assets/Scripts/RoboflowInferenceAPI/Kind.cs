using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the Kind schema.
/// </summary>
public class Kind
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [JsonProperty("name")] 
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [JsonProperty("description")] 
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the docs.
    /// </summary>
    [JsonProperty("docs")] 
    public string Docs { get; set; }

    /// <summary>
    /// Provides Python type hint for data format that should guide external clients on how to produce / consume serialised data of specific kind.
    /// </summary>
    [JsonProperty("serialised_data_type")] 
    public string Serialised_Data_Type { get; set; }

    /// <summary>
    /// Provides type hint regarding internal data representation that specific kind translates into when Workflow is run by Execution Engine. Relevant for blocks developers.
    /// </summary>
    [JsonProperty("internal_data_type")] 
    public string Internal_Data_Type { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Kind"/>.
    /// </summary>
    /// <param name="name">The name.</param>
    public Kind(string name)
    {
        this.Name = name;
    }
}