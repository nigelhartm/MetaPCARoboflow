using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request for gaze detection inference.
/// 
/// Attributes:
///     api_key (Optional[str]): Roboflow API Key.
///     owlv2_version_id (Optional[str]): The version ID of Gaze to be used for this request.
///     image (Union[List[InferenceRequestImage], InferenceRequestImage]): Image(s) for inference.
///     training_data (List[TrainingImage]): Training data to ground the model on
///     confidence (float): Confidence threshold to filter predictions by
/// </summary>
public class OwlV2InferenceRequest
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    [JsonProperty("id")] 
    public string Id { get; set; }

    /// <summary>
    /// Roboflow API Key that will be passed to the model during initialization for artifact retrieval
    /// </summary>
    [JsonProperty("api_key")] 
    public string Api_Key { get; set; }

    /// <summary>
    /// Gets or sets the usage_billable.
    /// </summary>
    [JsonProperty("usage_billable")] 
    public bool Usage_Billable { get; set; }

    /// <summary>
    /// Gets or sets the start.
    /// </summary>
    [JsonProperty("start")] 
    public float? Start { get; set; }

    /// <summary>
    /// Gets or sets the source.
    /// </summary>
    [JsonProperty("source")] 
    public string Source { get; set; }

    /// <summary>
    /// Gets or sets the source_info.
    /// </summary>
    [JsonProperty("source_info")] 
    public string Source_Info { get; set; }

    /// <summary>
    /// The version ID of owlv2 to be used for this request.
    /// </summary>
    [JsonProperty("owlv2_version_id")] 
    public string Owlv2_Version_Id { get; set; }

    /// <summary>
    /// Model id to be used in the request.
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// Images to run the model on
    /// </summary>
    [JsonProperty("image")] 
    [JsonConverter(typeof(SingleOrArrayConverter<InferenceRequestImage>))]
    public List<InferenceRequestImage> Image { get; set; }

    /// <summary>
    /// Training images for the owlvit model to learn form
    /// </summary>
    [JsonProperty("training_data")] 
    public List<TrainingImage> Training_Data { get; set; }

    /// <summary>
    /// Default confidence threshold for owlvit predictions. Needs to be much higher than you're used to, probably 0.99 - 0.9999
    /// </summary>
    [JsonProperty("confidence")] 
    public float? Confidence { get; set; }

    /// <summary>
    /// If true, the predictions will be drawn on the original image and returned as a base64 string
    /// </summary>
    [JsonProperty("visualize_predictions")] 
    public bool? Visualize_Predictions { get; set; }

    /// <summary>
    /// If true, labels will be rendered on prediction visualizations
    /// </summary>
    [JsonProperty("visualization_labels")] 
    public bool? Visualization_Labels { get; set; }

    /// <summary>
    /// The stroke width used when visualizing predictions
    /// </summary>
    [JsonProperty("visualization_stroke_width")] 
    public int? Visualization_Stroke_Width { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="OwlV2InferenceRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="image">The image.</param>
    /// <param name="training_Data">The training_Data.</param>
    public OwlV2InferenceRequest(string id, List<InferenceRequestImage> image, List<TrainingImage> training_Data)
    {
        this.Id = id;
        this.Image = image;
        this.Training_Data = training_Data;
    }
}