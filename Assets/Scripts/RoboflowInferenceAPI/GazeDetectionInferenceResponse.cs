using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Response for gaze detection inference.
/// 
/// Attributes:
///     predictions (List[inference.core.entities.responses.gaze.GazeDetectionPrediction]): List of gaze detection predictions.
///     time (float): The processing time (second).
/// </summary>
public class GazeDetectionInferenceResponse
{
    /// <summary>
    /// Gets or sets the predictions.
    /// </summary>
    [JsonProperty("predictions")] 
    public List<GazeDetectionPrediction> Predictions { get; set; }

    /// <summary>
    /// The processing time (second)
    /// </summary>
    [JsonProperty("time")] 
    public float Time { get; set; }

    /// <summary>
    /// The face detection time (second)
    /// </summary>
    [JsonProperty("time_face_det")] 
    public float? Time_Face_Det { get; set; }

    /// <summary>
    /// The gaze detection time (second)
    /// </summary>
    [JsonProperty("time_gaze_det")] 
    public float? Time_Gaze_Det { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="GazeDetectionInferenceResponse"/>.
    /// </summary>
    /// <param name="predictions">The predictions.</param>
    /// <param name="time">The time.</param>
    public GazeDetectionInferenceResponse(List<GazeDetectionPrediction> predictions, float time)
    {
        this.Predictions = predictions;
        this.Time = time;
    }
}