using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the Sam2Prompt schema.
/// </summary>
public class Sam2Prompt
{
    /// <summary>
    /// Gets or sets the box.
    /// </summary>
    [JsonProperty("box")] 
    public Box Box { get; set; }

    /// <summary>
    /// Gets or sets the points.
    /// </summary>
    [JsonProperty("points")] 
    public List<PointInput> Points { get; set; }

}