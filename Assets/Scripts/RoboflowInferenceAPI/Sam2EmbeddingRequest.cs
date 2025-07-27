using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// SAM embedding request.
/// 
/// Attributes:
///     image (Optional[inference.core.entities.requests.inference.InferenceRequestImage]): The image to be embedded.
///     image_id (Optional[str]): The ID of the image to be embedded used to cache the embedding.
///     format (Optional[str]): The format of the response. Must be one of json or binary.
/// </summary>
public class Sam2EmbeddingRequest
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
    /// The version ID of SAM to be used for this request. Must be one of hiera_tiny, hiera_small, hiera_large, hiera_b_plus
    /// </summary>
    [JsonProperty("sam2_version_id")] 
    public string Sam2_Version_Id { get; set; }

    /// <summary>
    /// Gets or sets the model_id.
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// The image to be embedded
    /// </summary>
    [JsonProperty("image")] 
    public InferenceRequestImage Image { get; set; }

    /// <summary>
    /// The ID of the image to be embedded used to cache the embedding.
    /// </summary>
    [JsonProperty("image_id")] 
    public string Image_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Sam2EmbeddingRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    public Sam2EmbeddingRequest(string id)
    {
        this.Id = id;
    }
}