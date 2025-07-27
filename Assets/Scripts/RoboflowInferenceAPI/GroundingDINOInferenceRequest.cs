using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request for Grounding DINO zero-shot predictions.
/// 
/// Attributes:
///     text (List[str]): A list of strings.
/// </summary>
public class GroundingDINOInferenceRequest
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
    /// Gets or sets the model_id.
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
    [JsonConverter(typeof(SingleOrArrayConverter<InferenceRequestImage>))]
    public List<InferenceRequestImage> Image { get; set; }

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
    /// A list of strings
    /// </summary>
    [JsonProperty("text")] 
    public List<string> Text { get; set; }

    /// <summary>
    /// Gets or sets the box_threshold.
    /// </summary>
    [JsonProperty("box_threshold")] 
    public float? Box_Threshold { get; set; }

    /// <summary>
    /// Gets or sets the grounding_dino_version_id.
    /// </summary>
    [JsonProperty("grounding_dino_version_id")] 
    public string Grounding_Dino_Version_Id { get; set; }

    /// <summary>
    /// Gets or sets the text_threshold.
    /// </summary>
    [JsonProperty("text_threshold")] 
    public float? Text_Threshold { get; set; }

    /// <summary>
    /// Gets or sets the class_agnostic_nms.
    /// </summary>
    [JsonProperty("class_agnostic_nms")] 
    public bool? Class_Agnostic_Nms { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="GroundingDINOInferenceRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="image">The image.</param>
    /// <param name="text">The text.</param>
    public GroundingDINOInferenceRequest(string id, List<InferenceRequestImage> image, List<string> text)
    {
        this.Id = id;
        this.Image = image;
        this.Text = text;
    }
}