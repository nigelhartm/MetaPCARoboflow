using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the LMMInferenceRequest schema.
/// </summary>
public class LMMInferenceRequest
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
    /// If set, use this prompt to guide the LMM
    /// </summary>
    [JsonProperty("prompt")] 
    public string Prompt { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="LMMInferenceRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="model_Id">The model_Id.</param>
    /// <param name="image">The image.</param>
    public LMMInferenceRequest(string id, string model_Id, List<InferenceRequestImage> image)
    {
        this.Id = id;
        this.Model_Id = model_Id;
        this.Image = image;
    }
}