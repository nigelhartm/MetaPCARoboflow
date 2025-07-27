using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Instance Segmentation inference request.
/// 
/// Attributes:
///     mask_decode_mode (Optional[str]): The mode used to decode instance segmentation masks, one of 'accurate', 'fast', 'tradeoff'.
///     tradeoff_factor (Optional[float]): The amount to tradeoff between 0='fast' and 1='accurate'.
/// </summary>
public class InstanceSegmentationInferenceRequest
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
    //[JsonConverter(typeof(SingleOrArrayConverter<InferenceRequestImage>))]
    //public List<InferenceRequestImage> Image { get; set; }
    public InferenceRequestImage Image { get; set; }

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
    /// If true, NMS is applied to all detections at once, if false, NMS is applied per class
    /// </summary>
    [JsonProperty("class_agnostic_nms")] 
    public bool? Class_Agnostic_Nms { get; set; }

    /// <summary>
    /// If provided, only predictions for the listed classes will be returned
    /// </summary>
    [JsonProperty("class_filter")] 
    public List<string> Class_Filter { get; set; }

    /// <summary>
    /// The confidence threshold used to filter out predictions
    /// </summary>
    [JsonProperty("confidence")] 
    public float? Confidence { get; set; }

    /// <summary>
    /// If true, the batch size will be fixed to the maximum batch size configured for this server
    /// </summary>
    [JsonProperty("fix_batch_size")] 
    public bool? Fix_Batch_Size { get; set; }

    /// <summary>
    /// The IoU threhsold that must be met for a box pair to be considered duplicate during NMS
    /// </summary>
    [JsonProperty("iou_threshold")] 
    public float? Iou_Threshold { get; set; }

    /// <summary>
    /// The maximum number of detections that will be returned
    /// </summary>
    [JsonProperty("max_detections")] 
    public int? Max_Detections { get; set; }

    /// <summary>
    /// The maximum number of candidate detections passed to NMS
    /// </summary>
    [JsonProperty("max_candidates")] 
    public int? Max_Candidates { get; set; }

    /// <summary>
    /// If true, labels will be rendered on prediction visualizations
    /// </summary>
    [JsonProperty("visualization_labels")] 
    public bool? Visualization_Labels { get; set; }

    /// <summary>
    /// The stroke width used when visualizing predictions
    /// </summary>
    [JsonProperty("visualization_stroke_width")] 
    public int? Visualization_Stroke_Width { get; set; }

    /// <summary>
    /// If true, the predictions will be drawn on the original image and returned as a base64 string
    /// </summary>
    [JsonProperty("visualize_predictions")] 
    public bool? Visualize_Predictions { get; set; }

    /// <summary>
    /// If true, the predictions will be prevented from registration by Active Learning (if the functionality is enabled)
    /// </summary>
    [JsonProperty("disable_active_learning")] 
    public bool? Disable_Active_Learning { get; set; }

    /// <summary>
    /// Parameter to be used when Active Learning data registration should happen against different dataset than the one pointed by model_id
    /// </summary>
    [JsonProperty("active_learning_target_dataset")] 
    public string Active_Learning_Target_Dataset { get; set; }

    /// <summary>
    /// The mode used to decode instance segmentation masks, one of 'accurate', 'fast', 'tradeoff'
    /// </summary>
    [JsonProperty("mask_decode_mode")] 
    public string Mask_Decode_Mode { get; set; }

    /// <summary>
    /// The amount to tradeoff between 0='fast' and 1='accurate'
    /// </summary>
    [JsonProperty("tradeoff_factor")] 
    public float? Tradeoff_Factor { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InstanceSegmentationInferenceRequest"/>.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="model_Id">The model_Id.</param>
    /// <param name="image">The image.</param>
    //public InstanceSegmentationInferenceRequest(string id, string model_Id, List<InferenceRequestImage> image)
    public InstanceSegmentationInferenceRequest(string model_Id, InferenceRequestImage image, string id="0")
    {
        this.Id = id;
        this.Model_Id = model_Id;
        this.Image = image;
    }
}