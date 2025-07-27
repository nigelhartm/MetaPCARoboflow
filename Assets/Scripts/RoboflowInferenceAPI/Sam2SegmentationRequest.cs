using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// SAM segmentation request.
/// 
/// Attributes:
///     format (Optional[str]): The format of the response.
///     image (InferenceRequestImage): The image to be segmented.
///     image_id (Optional[str]): The ID of the image to be segmented used to retrieve cached embeddings.
///     point_coords (Optional[List[List[float]]]): The coordinates of the interactive points used during decoding.
///     point_labels (Optional[List[float]]): The labels of the interactive points used during decoding.
/// </summary>
public class Sam2SegmentationRequest
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
    /// The format of the response. Must be one of json or binary. If binary, masks are returned as binary numpy arrays. If json, masks are converted to polygons, then returned as json.
    /// </summary>
    [JsonProperty("format")] 
    public string Format { get; set; }

    /// <summary>
    /// The image to be segmented.
    /// </summary>
    [JsonProperty("image")] 
    public InferenceRequestImage Image { get; set; }

    /// <summary>
    /// The ID of the image to be segmented used to retrieve cached embeddings. If an embedding is cached, it will be used instead of generating a new embedding. If no embedding is cached, a new embedding will be generated and cached.
    /// </summary>
    [JsonProperty("image_id")] 
    public string Image_Id { get; set; }

    /// <summary>
    /// A list of prompts for masks to predict. Each prompt can include a bounding box and / or a set of postive or negative points
    /// </summary>
    [JsonProperty("prompts")] 
    public Sam2PromptSet Prompts { get; set; }

    /// <summary>
    /// If true, the model will return three masks. For ambiguous input prompts (such as a single click), this will often produce better masks than a single prediction. If only a single mask is needed, the model's predicted quality score can be used to select the best mask. For non-ambiguous prompts, such as multiple input prompts, multimask_output=False can give better results.
    /// </summary>
    [JsonProperty("multimask_output")] 
    public bool Multimask_Output { get; set; }

    /// <summary>
    /// If True, saves the low-resolution logits to the cache for potential future use. This can speed up subsequent requests with similar prompts on the same image. This feature is ignored if DISABLE_SAM2_LOGITS_CACHE env variable is set True
    /// </summary>
    [JsonProperty("save_logits_to_cache")] 
    public bool Save_Logits_To_Cache { get; set; }

    /// <summary>
    /// If True, attempts to load previously cached low-resolution logits for the given image and prompt set. This can significantly speed up inference when making multiple similar requests on the same image. This feature is ignored if DISABLE_SAM2_LOGITS_CACHE env variable is set True
    /// </summary>
    [JsonProperty("load_logits_from_cache")] 
    public bool Load_Logits_From_Cache { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Sam2SegmentationRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="image">The image.</param>
    public Sam2SegmentationRequest(string id, InferenceRequestImage image)
    {
        this.Id = id;
        this.Image = image;
    }
}