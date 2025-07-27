using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Point coordinates.
/// 
/// Attributes:
///     x (float): The x-axis pixel coordinate of the point.
///     y (float): The y-axis pixel coordinate of the point.
/// </summary>
public class PointOutput
{
    /// <summary>
    /// The x-axis pixel coordinate of the point
    /// </summary>
    [JsonProperty("x")] 
    public float X { get; set; }

    /// <summary>
    /// The y-axis pixel coordinate of the point
    /// </summary>
    [JsonProperty("y")] 
    public float Y { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="PointOutput"/>.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public PointOutput(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }
}