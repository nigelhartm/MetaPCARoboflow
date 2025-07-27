using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Multi-label Classification inference response.
/// 
/// Attributes:
///     predictions (Dict[str, inference.core.entities.responses.inference.MultiLabelClassificationPrediction]): Dictionary of multi-label classification predictions.
///     predicted_classes (List[str]): The list of predicted classes.
/// </summary>
public class MultiLabelClassificationInferenceResponse
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
    public object Predictions { get; set; }

    /// <summary>
    /// The list of predicted classes
    /// </summary>
    [JsonProperty("predicted_classes")] 
    public List<string> Predicted_Classes { get; set; }

    /// <summary>
    /// Identifier of parent image region. Useful when stack of detection-models is in use to refer the RoI being the input to inference
    /// </summary>
    [JsonProperty("parent_id")] 
    public string Parent_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="MultiLabelClassificationInferenceResponse"/>.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="predictions">The predictions.</param>
    /// <param name="predicted_Classes">The predicted_Classes.</param>
    public MultiLabelClassificationInferenceResponse(List<InferenceResponseImage> image, object predictions, List<string> predicted_Classes)
    {
        this.Image = image;
        this.Predictions = predictions;
        this.Predicted_Classes = predicted_Classes;
    }
}