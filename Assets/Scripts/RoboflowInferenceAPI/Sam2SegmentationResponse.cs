using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the Sam2SegmentationResponse schema.
/// </summary>
public class Sam2SegmentationResponse
{
    /// <summary>
    /// Gets or sets the predictions.
    /// </summary>
    [JsonProperty("predictions")] 
    public List<Sam2SegmentationPrediction> Predictions { get; set; }

    /// <summary>
    /// The time in seconds it took to produce the segmentation including preprocessing
    /// </summary>
    [JsonProperty("time")] 
    public float Time { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Sam2SegmentationResponse"/>.
    /// </summary>
    /// <param name="predictions">The predictions.</param>
    /// <param name="time">The time.</param>
    public Sam2SegmentationResponse(List<Sam2SegmentationPrediction> predictions, float time)
    {
        this.Predictions = predictions;
        this.Time = time;
    }
}