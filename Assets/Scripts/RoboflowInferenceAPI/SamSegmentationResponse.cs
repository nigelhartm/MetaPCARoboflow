using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// SAM segmentation response.
/// 
/// Attributes:
///     masks (Union[List[List[List[int]]], Any]): The set of output masks.
///     low_res_masks (Union[List[List[List[int]]], Any]): The set of output low-resolution masks.
///     time (float): The time in seconds it took to produce the segmentation including preprocessing.
/// </summary>
public class SamSegmentationResponse
{
    /// <summary>
    /// The set of output masks. If request format is json, masks is a list of polygons, where each polygon is a list of points, where each point is a tuple containing the x,y pixel coordinates of the point. If request format is binary, masks is a list of binary numpy arrays. The dimensions of each mask are the same as the dimensions of the input image.
    /// </summary>
    [JsonProperty("masks")] 
    public List<List<List<int>>> Masks { get; set; }

    /// <summary>
    /// The set of output masks. If request format is json, masks is a list of polygons, where each polygon is a list of points, where each point is a tuple containing the x,y pixel coordinates of the point. If request format is binary, masks is a list of binary numpy arrays. The dimensions of each mask are 256 x 256
    /// </summary>
    [JsonProperty("low_res_masks")] 
    public List<List<List<int>>> Low_Res_Masks { get; set; }

    /// <summary>
    /// The time in seconds it took to produce the segmentation including preprocessing
    /// </summary>
    [JsonProperty("time")] 
    public float Time { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="SamSegmentationResponse"/>.
    /// </summary>
    /// <param name="masks">The masks.</param>
    /// <param name="low_Res_Masks">The low_Res_Masks.</param>
    /// <param name="time">The time.</param>
    public SamSegmentationResponse(List<List<List<int>>> masks, List<List<List<int>>> low_Res_Masks, float time)
    {
        this.Masks = masks;
        this.Low_Res_Masks = low_Res_Masks;
        this.Time = time;
    }
}