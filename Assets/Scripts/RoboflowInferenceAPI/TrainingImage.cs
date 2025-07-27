using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the TrainingImage schema.
/// </summary>
public class TrainingImage
{
    /// <summary>
    /// List of boxes and corresponding classes of examples for the model to learn from
    /// </summary>
    [JsonProperty("boxes")] 
    public List<TrainBox> Boxes { get; set; }

    /// <summary>
    /// Image data that `boxes` describes
    /// </summary>
    [JsonProperty("image")] 
    public InferenceRequestImage Image { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="TrainingImage"/>.
    /// </summary>
    /// <param name="boxes">The boxes.</param>
    /// <param name="image">The image.</param>
    public TrainingImage(List<TrainBox> boxes, InferenceRequestImage image)
    {
        this.Boxes = boxes;
        this.Image = image;
    }
}