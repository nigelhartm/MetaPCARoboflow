using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// SAM segmentation prediction.
/// 
/// Attributes:
///     masks (Union[List[List[List[int]]], Any]): The set of output masks.
///     low_res_masks (Union[List[List[List[int]]], Any]): The set of output low-resolution masks.
///     time (float): The time in seconds it took to produce the segmentation including preprocessing.
/// </summary>
public class Sam2SegmentationPrediction
{
    /// <summary>
    /// The set of points for output mask as polygon. Each element of list represents single point.
    /// </summary>
    [JsonProperty("masks")] 
    public List<List<List<int>>> Masks { get; set; }

    /// <summary>
    /// Masks confidences
    /// </summary>
    [JsonProperty("confidence")] 
    public float Confidence { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Sam2SegmentationPrediction"/>.
    /// </summary>
    /// <param name="masks">The masks.</param>
    /// <param name="confidence">The confidence.</param>
    public Sam2SegmentationPrediction(List<List<List<int>>> masks, float confidence)
    {
        this.Masks = masks;
        this.Confidence = confidence;
    }
}