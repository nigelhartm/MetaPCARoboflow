using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request for gaze detection inference.
/// 
/// Attributes:
///     api_key (Optional[str]): Roboflow API Key.
///     gaze_version_id (Optional[str]): The version ID of Gaze to be used for this request.
///     do_run_face_detection (Optional[bool]): If true, face detection will be applied; if false, face detection will be ignored and the whole input image will be used for gaze detection.
///     image (Union[List[InferenceRequestImage], InferenceRequestImage]): Image(s) for inference.
/// </summary>
public class GazeDetectionInferenceRequest
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
    /// The version ID of Gaze to be used for this request. Must be one of l2cs.
    /// </summary>
    [JsonProperty("gaze_version_id")] 
    public string Gaze_Version_Id { get; set; }

    /// <summary>
    /// If true, face detection will be applied; if false, face detection will be ignored and the whole input image will be used for gaze detection
    /// </summary>
    [JsonProperty("do_run_face_detection")] 
    public bool? Do_Run_Face_Detection { get; set; }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    [JsonProperty("image")] 
    [JsonConverter(typeof(SingleOrArrayConverter<InferenceRequestImage>))]
    public List<InferenceRequestImage> Image { get; set; }

    /// <summary>
    /// Gets or sets the model_id.
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="GazeDetectionInferenceRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="image">The image.</param>
    public GazeDetectionInferenceRequest(string id, List<InferenceRequestImage> image)
    {
        this.Id = id;
        this.Image = image;
    }
}