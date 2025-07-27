using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Inference response image information.
/// 
/// Attributes:
///     width (int): The original width of the image used in inference.
///     height (int): The original height of the image used in inference.
/// </summary>
public class InferenceResponseImage
{
    /// <summary>
    /// The original width of the image used in inference
    /// </summary>
    [JsonProperty("width")] 
    public int Width { get; set; }

    /// <summary>
    /// The original height of the image used in inference
    /// </summary>
    [JsonProperty("height")] 
    public int Height { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InferenceResponseImage"/>.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public InferenceResponseImage(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }
}