using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Response for depth estimation inference.
/// 
/// Attributes:
///     normalized_depth (List[List[float]]): The normalized depth map as a 2D array of floats between 0 and 1.
///     image (Optional[str]): Base64 encoded visualization of the depth map if visualize_predictions is True.
///     time (float): The processing time in seconds.
///     visualization (Optional[str]): Base64 encoded visualization of the depth map if visualize_predictions is True.
/// </summary>
public class DepthEstimationResponse
{
    /// <summary>
    /// The normalized depth map as a 2D array of floats between 0 and 1
    /// </summary>
    [JsonProperty("normalized_depth")] 
    public List<List<float>> Normalized_Depth { get; set; }

    /// <summary>
    /// Base64 encoded visualization of the depth map if visualize_predictions is True
    /// </summary>
    [JsonProperty("image")] 
    public string Image { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="DepthEstimationResponse"/>.
    /// </summary>
    /// <param name="normalized_Depth">The normalized_Depth.</param>
    public DepthEstimationResponse(List<List<float>> normalized_Depth)
    {
        this.Normalized_Depth = normalized_Depth;
    }
}