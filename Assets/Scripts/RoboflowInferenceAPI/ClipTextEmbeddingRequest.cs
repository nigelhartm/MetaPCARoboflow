using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request for CLIP text embedding.
/// 
/// Attributes:
///     text (Union[List[str], str]): A string or list of strings.
/// </summary>
public class ClipTextEmbeddingRequest
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
    /// The version ID of CLIP to be used for this request. Must be one of RN101, RN50, RN50x16, RN50x4, RN50x64, ViT-B-16, ViT-B-32, ViT-L-14-336px, and ViT-L-14.
    /// </summary>
    [JsonProperty("clip_version_id")] 
    public string Clip_Version_Id { get; set; }

    /// <summary>
    /// Gets or sets the model_id.
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// A string or list of strings
    /// </summary>
    [JsonProperty("text")] 
    public List<string> Text { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ClipTextEmbeddingRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="text">The text.</param>
    public ClipTextEmbeddingRequest(string id, List<string> text)
    {
        this.Id = id;
        this.Text = text;
    }
}