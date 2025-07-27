using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request for PERCEPTION_ENCODER image embedding.
/// 
/// Attributes:
///     image (Union[List[InferenceRequestImage], InferenceRequestImage]): Image(s) to be embedded.
/// </summary>
public class PerceptionEncoderImageEmbeddingRequest
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
    /// The version ID of PERCEPTION_ENCODER to be used for this request. Must be one of RN101, RN50, RN50x16, RN50x4, RN50x64, ViT-B-16, ViT-B-32, ViT-L-14-336px, and ViT-L-14.
    /// </summary>
    [JsonProperty("perception_encoder_version_id")] 
    public string Perception_Encoder_Version_Id { get; set; }

    /// <summary>
    /// Gets or sets the model_id.
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    [JsonProperty("image")] 
    [JsonConverter(typeof(SingleOrArrayConverter<InferenceRequestImage>))]
    public List<InferenceRequestImage> Image { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="PerceptionEncoderImageEmbeddingRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="image">The image.</param>
    public PerceptionEncoderImageEmbeddingRequest(string id, List<InferenceRequestImage> image)
    {
        this.Id = id;
        this.Image = image;
    }
}