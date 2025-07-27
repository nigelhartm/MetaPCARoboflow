using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request for depth estimation.
/// 
/// Attributes:
///     image (Union[List[InferenceRequestImage], InferenceRequestImage]): Image(s) to be estimated.
///     model_id (str): The model ID to use for depth estimation.
///     depth_version_id (Optional[str]): The version ID of the depth estimation model.
/// </summary>
public class DepthEstimationRequest
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
    /// The version ID of the depth estimation model
    /// </summary>
    [JsonProperty("depth_version_id")] 
    public string Depth_Version_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="DepthEstimationRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="image">The image.</param>
    public DepthEstimationRequest(string id, List<InferenceRequestImage> image)
    {
        this.Id = id;
        this.Image = image;
    }
}