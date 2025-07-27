using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the Keypoint schema.
/// </summary>
public class Keypoint
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
    /// Model confidence regarding keypoint visibility.
    /// </summary>
    [JsonProperty("confidence")] 
    public float Confidence { get; set; }

    /// <summary>
    /// Identifier of keypoint.
    /// </summary>
    [JsonProperty("class_id")] 
    public int Class_Id { get; set; }

    /// <summary>
    /// Type of keypoint.
    /// </summary>
    [JsonProperty("class")] 
    public string Class { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Keypoint"/>.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="confidence">The confidence.</param>
    /// <param name="class_Id">The class_Id.</param>
    /// <param name="@class">The @class.</param>
    public Keypoint(float x, float y, float confidence, int class_Id, string @class)
    {
        this.X = x;
        this.Y = y;
        this.Confidence = confidence;
        this.Class_Id = class_Id;
        this.Class = @class;
    }
}