using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the PointInput schema.
/// </summary>
public class PointInput
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
    /// Gets or sets the positive.
    /// </summary>
    [JsonProperty("positive")] 
    public bool Positive { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="PointInput"/>.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="positive">The positive.</param>
    public PointInput(float x, float y, bool positive)
    {
        this.X = x;
        this.Y = y;
        this.Positive = positive;
    }
}