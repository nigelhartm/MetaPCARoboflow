using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the Box schema.
/// </summary>
public class Box
{
    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    [JsonProperty("x")] 
    public float X { get; set; }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    [JsonProperty("y")] 
    public float Y { get; set; }

    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    [JsonProperty("width")] 
    public float Width { get; set; }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    [JsonProperty("height")] 
    public float Height { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Box"/>.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public Box(float x, float y, float width, float height)
    {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }
}