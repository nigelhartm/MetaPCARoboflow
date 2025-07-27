using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Instance Segmentation inference response.
/// 
/// Attributes:
///     predictions (List[inference.core.entities.responses.inference.InstanceSegmentationPrediction]): List of instance segmentation predictions.
/// </summary>
public class InstanceSegmentationInferenceResponse
{
    /// <summary>
    /// Base64 encoded string containing prediction visualization image data
    /// </summary>
    [JsonProperty("visualization")] 
    public string Visualization { get; set; }

    /// <summary>
    /// Unique identifier of inference
    /// </summary>
    [JsonProperty("inference_id")] 
    public string Inference_Id { get; set; }

    /// <summary>
    /// The frame id of the image used in inference if the input was a video
    /// </summary>
    [JsonProperty("frame_id")] 
    public int? Frame_Id { get; set; }

    /// <summary>
    /// The time in seconds it took to produce the predictions including image preprocessing
    /// </summary>
    [JsonProperty("time")] 
    public float? Time { get; set; }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    [JsonProperty("image")] 
    [JsonConverter(typeof(SingleOrArrayConverter<InferenceResponseImage>))]
    public List<InferenceResponseImage> Image { get; set; }

    /// <summary>
    /// Gets or sets the predictions.
    /// </summary>
    [JsonProperty("predictions")] 
    public List<InstanceSegmentationPrediction> Predictions { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InstanceSegmentationInferenceResponse"/>.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="predictions">The predictions.</param>
    public InstanceSegmentationInferenceResponse(List<InferenceResponseImage> image, List<InstanceSegmentationPrediction> predictions)
    {
        this.Image = image;
        this.Predictions = predictions;
    }
}