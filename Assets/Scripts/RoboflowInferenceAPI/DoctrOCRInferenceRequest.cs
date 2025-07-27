using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// DocTR inference request.
/// 
/// Attributes:
///     api_key (Optional[str]): Roboflow API Key.
/// </summary>
public class DoctrOCRInferenceRequest
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
    /// Gets or sets the image.
    /// </summary>
    [JsonProperty("image")] 
    [JsonConverter(typeof(SingleOrArrayConverter<InferenceRequestImage>))]
    public List<InferenceRequestImage> Image { get; set; }

    /// <summary>
    /// Gets or sets the doctr_version_id.
    /// </summary>
    [JsonProperty("doctr_version_id")] 
    public string Doctr_Version_Id { get; set; }

    /// <summary>
    /// Gets or sets the model_id.
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="DoctrOCRInferenceRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="image">The image.</param>
    public DoctrOCRInferenceRequest(string id, List<InferenceRequestImage> image)
    {
        this.Id = id;
        this.Image = image;
    }
}