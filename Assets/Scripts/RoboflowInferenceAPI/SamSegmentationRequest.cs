using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// SAM segmentation request.
/// 
/// Attributes:
///     embeddings (Optional[Union[List[List[List[List[float]]]], Any]]): The embeddings to be decoded.
///     embeddings_format (Optional[str]): The format of the embeddings.
///     format (Optional[str]): The format of the response.
///     image (Optional[InferenceRequestImage]): The image to be segmented.
///     image_id (Optional[str]): The ID of the image to be segmented used to retrieve cached embeddings.
///     has_mask_input (Optional[bool]): Whether or not the request includes a mask input.
///     mask_input (Optional[Union[List[List[List[float]]], Any]]): The set of output masks.
///     mask_input_format (Optional[str]): The format of the mask input.
///     orig_im_size (Optional[List[int]]): The original size of the image used to generate the embeddings.
///     point_coords (Optional[List[List[float]]]): The coordinates of the interactive points used during decoding.
///     point_labels (Optional[List[float]]): The labels of the interactive points used during decoding.
///     use_mask_input_cache (Optional[bool]): Whether or not to use the mask input cache.
/// </summary>
public class SamSegmentationRequest
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
    /// The version ID of SAM to be used for this request. Must be one of vit_h, vit_l, or vit_b.
    /// </summary>
    [JsonProperty("sam_version_id")] 
    public string Sam_Version_Id { get; set; }

    /// <summary>
    /// Gets or sets the model_id.
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// The embeddings to be decoded. The dimensions of the embeddings are 1 x 256 x 64 x 64. If embeddings is not provided, image must be provided.
    /// </summary>
    [JsonProperty("embeddings")] 
    public List<List<List<List<float>>>> Embeddings { get; set; }

    /// <summary>
    /// The format of the embeddings. Must be one of json or binary. If binary, embeddings are expected to be a binary numpy array.
    /// </summary>
    [JsonProperty("embeddings_format")] 
    public string Embeddings_Format { get; set; }

    /// <summary>
    /// The format of the response. Must be one of json or binary. If binary, masks are returned as binary numpy arrays. If json, masks are converted to polygons, then returned as json.
    /// </summary>
    [JsonProperty("format")] 
    public string Format { get; set; }

    /// <summary>
    /// The image to be segmented. Only required if embeddings are not provided.
    /// </summary>
    [JsonProperty("image")] 
    public InferenceRequestImage Image { get; set; }

    /// <summary>
    /// The ID of the image to be segmented used to retrieve cached embeddings. If an embedding is cached, it will be used instead of generating a new embedding. If no embedding is cached, a new embedding will be generated and cached.
    /// </summary>
    [JsonProperty("image_id")] 
    public string Image_Id { get; set; }

    /// <summary>
    /// Whether or not the request includes a mask input. If true, the mask input must be provided.
    /// </summary>
    [JsonProperty("has_mask_input")] 
    public bool? Has_Mask_Input { get; set; }

    /// <summary>
    /// The set of output masks. If request format is json, masks is a list of polygons, where each polygon is a list of points, where each point is a tuple containing the x,y pixel coordinates of the point. If request format is binary, masks is a list of binary numpy arrays. The dimensions of each mask are 256 x 256. This is the same as the output, low resolution mask from the previous inference.
    /// </summary>
    [JsonProperty("mask_input")] 
    public List<List<List<float>>> Mask_Input { get; set; }

    /// <summary>
    /// The format of the mask input. Must be one of json or binary. If binary, mask input is expected to be a binary numpy array.
    /// </summary>
    [JsonProperty("mask_input_format")] 
    public string Mask_Input_Format { get; set; }

    /// <summary>
    /// The original size of the image used to generate the embeddings. This is only required if the image is not provided.
    /// </summary>
    [JsonProperty("orig_im_size")] 
    public List<int> Orig_Im_Size { get; set; }

    /// <summary>
    /// The coordinates of the interactive points used during decoding. Each point (x,y pair) corresponds to a label in point_labels.
    /// </summary>
    [JsonProperty("point_coords")] 
    public List<List<float>> Point_Coords { get; set; }

    /// <summary>
    /// The labels of the interactive points used during decoding. A 1 represents a positive point (part of the object to be segmented). A -1 represents a negative point (not part of the object to be segmented). Each label corresponds to a point in point_coords.
    /// </summary>
    [JsonProperty("point_labels")] 
    public List<float> Point_Labels { get; set; }

    /// <summary>
    /// Whether or not to use the mask input cache. If true, the mask input cache will be used if it exists. If false, the mask input cache will not be used.
    /// </summary>
    [JsonProperty("use_mask_input_cache")] 
    public bool? Use_Mask_Input_Cache { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="SamSegmentationRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    public SamSegmentationRequest(string id)
    {
        this.Id = id;
    }
}