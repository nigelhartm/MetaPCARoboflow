using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// 3D Point coordinates.
/// 
/// Attributes:
///     z (float): The z-axis pixel coordinate of the point.
/// </summary>
public class Point3D
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
    /// The z-axis pixel coordinate of the point
    /// </summary>
    [JsonProperty("z")] 
    public float Z { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Point3D"/>.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    public Point3D(float x, float y, float z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }
}