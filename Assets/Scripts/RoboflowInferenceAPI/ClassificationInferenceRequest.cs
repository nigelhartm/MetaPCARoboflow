using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Classification inference request.
/// 
/// Attributes:
///     confidence (Optional[float]): The confidence threshold used to filter out predictions.
///     visualization_stroke_width (Optional[int]): The stroke width used when visualizing predictions.
///     visualize_predictions (Optional[bool]): If true, the predictions will be drawn on the original image and returned as a base64 string.
/// </summary>
public class ClassificationInferenceRequest
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
    /// A unique model identifier
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// The type of the model, usually referring to what task the model performs
    /// </summary>
    [JsonProperty("model_type")] 
    public string Model_Type { get; set; }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    [JsonProperty("image")]
    //[JsonConverter(typeof(SingleOrArrayConverter<InferenceRequestImage>))]
    //public List<InferenceRequestImage> Image { get; set; }
    public InferenceRequestImage Image { get; set; }

    /// <summary>
    /// If true, the auto orient preprocessing step is disabled for this call.
    /// </summary>
    [JsonProperty("disable_preproc_auto_orient")] 
    public bool? Disable_Preproc_Auto_Orient { get; set; }

    /// <summary>
    /// If true, the auto contrast preprocessing step is disabled for this call.
    /// </summary>
    [JsonProperty("disable_preproc_contrast")] 
    public bool? Disable_Preproc_Contrast { get; set; }

    /// <summary>
    /// If true, the grayscale preprocessing step is disabled for this call.
    /// </summary>
    [JsonProperty("disable_preproc_grayscale")] 
    public bool? Disable_Preproc_Grayscale { get; set; }

    /// <summary>
    /// If true, the static crop preprocessing step is disabled for this call.
    /// </summary>
    [JsonProperty("disable_preproc_static_crop")] 
    public bool? Disable_Preproc_Static_Crop { get; set; }

    /// <summary>
    /// The confidence threshold used to filter out predictions
    /// </summary>
    [JsonProperty("confidence")] 
    public float? Confidence { get; set; }

    /// <summary>
    /// The stroke width used when visualizing predictions
    /// </summary>
    [JsonProperty("visualization_stroke_width")] 
    public int? Visualization_Stroke_Width { get; set; }

    /// <summary>
    /// If true, the predictions will be drawn on the original image and returned as a base64 string
    /// </summary>
    [JsonProperty("visualize_predictions")] 
    public bool? Visualize_Predictions { get; set; }

    /// <summary>
    /// If true, the predictions will be prevented from registration by Active Learning (if the functionality is enabled)
    /// </summary>
    [JsonProperty("disable_active_learning")] 
    public bool? Disable_Active_Learning { get; set; }

    /// <summary>
    /// Parameter to be used when Active Learning data registration should happen against different dataset than the one pointed by model_id
    /// </summary>
    [JsonProperty("active_learning_target_dataset")] 
    public string Active_Learning_Target_Dataset { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ClassificationInferenceRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="model_Id">The model_Id.</param>
    /// <param name="image">The image.</param>
    //public ClassificationInferenceRequest(string id, string model_Id, List<InferenceRequestImage> image)
    public ClassificationInferenceRequest(string model_Id, InferenceRequestImage image, string id="0")
    {
        this.Id = id;
        this.Model_Id = model_Id;
        this.Image = image;
    }
}