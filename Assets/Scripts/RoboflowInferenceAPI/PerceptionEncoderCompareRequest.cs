using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request for PERCEPTION_ENCODER comparison.
/// 
/// Attributes:
///     subject (Union[InferenceRequestImage, str]): The type of image data provided, one of 'url' or 'base64'.
///     subject_type (str): The type of subject, one of 'image' or 'text'.
///     prompt (Union[List[InferenceRequestImage], InferenceRequestImage, str, List[str], Dict[str, Union[InferenceRequestImage, str]]]): The prompt for comparison.
///     prompt_type (str): The type of prompt, one of 'image' or 'text'.
/// </summary>
public class PerceptionEncoderCompareRequest
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
    /// The type of image data provided, one of 'url' or 'base64'
    /// </summary>
    [JsonProperty("subject")] 
    public string Subject { get; set; }

    /// <summary>
    /// The type of subject, one of 'image' or 'text'
    /// </summary>
    [JsonProperty("subject_type")] 
    public string Subject_Type { get; set; }

    /// <summary>
    /// Gets or sets the prompt.
    /// </summary>
    [JsonProperty("prompt")] 
    [JsonConverter(typeof(SingleOrArrayConverter<string>))]
    public List<string> Prompt { get; set; }

    /// <summary>
    /// The type of prompt, one of 'image' or 'text'
    /// </summary>
    [JsonProperty("prompt_type")] 
    public string Prompt_Type { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="PerceptionEncoderCompareRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="subject">The subject.</param>
    /// <param name="prompt">The prompt.</param>
    public PerceptionEncoderCompareRequest(string id, string subject, List<string> prompt)
    {
        this.Id = id;
        this.Subject = subject;
        this.Prompt = prompt;
    }
}