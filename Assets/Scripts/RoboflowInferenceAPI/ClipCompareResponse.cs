using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Response for CLIP comparison.
/// 
/// Attributes:
///     similarity (Union[List[float], Dict[str, float]]): Similarity scores.
///     time (float): The time in seconds it took to produce the similarity scores including preprocessing.
/// </summary>
public class ClipCompareResponse
{
    /// <summary>
    /// Unique identifier of inference
    /// </summary>
    [JsonProperty("inference_id")] 
    public string Inference_Id { get; set; }

    /// <summary>
    /// The frame id of the image used in inference if the input was a video
    /// </summary>
    [JsonProperty("frame_id")] 
    public int? Frame_Id { get; set; }

    /// <summary>
    /// The time in seconds it took to produce the similarity scores including preprocessing
    /// </summary>
    [JsonProperty("time")] 
    public float? Time { get; set; }

    /// <summary>
    /// Gets or sets the similarity.
    /// </summary>
    [JsonProperty("similarity")] 
    public List<float> Similarity { get; set; }

    /// <summary>
    /// Identifier of parent image region. Useful when stack of detection-models is in use to refer the RoI being the input to inference
    /// </summary>
    [JsonProperty("parent_id")] 
    public string Parent_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ClipCompareResponse"/>.
    /// </summary>
    /// <param name="similarity">The similarity.</param>
    public ClipCompareResponse(List<float> similarity)
    {
        this.Similarity = similarity;
    }
}