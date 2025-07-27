using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the KeypointsPrediction schema.
/// </summary>
public class KeypointsPrediction
{
    /// <summary>
    /// The center x-axis pixel coordinate of the prediction
    /// </summary>
    [JsonProperty("x")] 
    public float X { get; set; }

    /// <summary>
    /// The center y-axis pixel coordinate of the prediction
    /// </summary>
    [JsonProperty("y")] 
    public float Y { get; set; }

    /// <summary>
    /// The width of the prediction bounding box in number of pixels
    /// </summary>
    [JsonProperty("width")] 
    public float Width { get; set; }

    /// <summary>
    /// The height of the prediction bounding box in number of pixels
    /// </summary>
    [JsonProperty("height")] 
    public float Height { get; set; }

    /// <summary>
    /// The detection confidence as a fraction between 0 and 1
    /// </summary>
    [JsonProperty("confidence")] 
    public float Confidence { get; set; }

    /// <summary>
    /// The predicted class label
    /// </summary>
    [JsonProperty("class")] 
    public string Class { get; set; }

    /// <summary>
    /// The class label confidence as a fraction between 0 and 1
    /// </summary>
    [JsonProperty("class_confidence")] 
    public float? Class_Confidence { get; set; }

    /// <summary>
    /// The class id of the prediction
    /// </summary>
    [JsonProperty("class_id")] 
    public int Class_Id { get; set; }

    /// <summary>
    /// The tracker id of the prediction if tracking is enabled
    /// </summary>
    [JsonProperty("tracker_id")] 
    public int? Tracker_Id { get; set; }

    /// <summary>
    /// Unique identifier of detection
    /// </summary>
    [JsonProperty("detection_id")] 
    public string Detection_Id { get; set; }

    /// <summary>
    /// Identifier of parent image region. Useful when stack of detection-models is in use to refer the RoI being the input to inference
    /// </summary>
    [JsonProperty("parent_id")] 
    public string Parent_Id { get; set; }

    /// <summary>
    /// Gets or sets the keypoints.
    /// </summary>
    [JsonProperty("keypoints")] 
    public List<Keypoint> Keypoints { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="KeypointsPrediction"/>.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="confidence">The confidence.</param>
    /// <param name="@class">The @class.</param>
    /// <param name="class_Id">The class_Id.</param>
    /// <param name="keypoints">The keypoints.</param>
    public KeypointsPrediction(float x, float y, float width, float height, float confidence, string @class, int class_Id, List<Keypoint> keypoints)
    {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
        this.Confidence = confidence;
        this.Class = @class;
        this.Class_Id = class_Id;
        this.Keypoints = keypoints;
    }
}