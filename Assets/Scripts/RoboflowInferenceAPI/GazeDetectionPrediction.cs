using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Gaze Detection prediction.
/// 
/// Attributes:
///     face (inference.core.entities.responses.inference.FaceDetectionPrediction): The face prediction.
///     yaw (float): Yaw (radian) of the detected face.
///     pitch (float): Pitch (radian) of the detected face.
/// </summary>
public class GazeDetectionPrediction
{
    /// <summary>
    /// Gets or sets the face.
    /// </summary>
    [JsonProperty("face")] 
    public FaceDetectionPrediction Face { get; set; }

    /// <summary>
    /// Yaw (radian) of the detected face
    /// </summary>
    [JsonProperty("yaw")] 
    public float Yaw { get; set; }

    /// <summary>
    /// Pitch (radian) of the detected face
    /// </summary>
    [JsonProperty("pitch")] 
    public float Pitch { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="GazeDetectionPrediction"/>.
    /// </summary>
    /// <param name="face">The face.</param>
    /// <param name="yaw">The yaw.</param>
    /// <param name="pitch">The pitch.</param>
    public GazeDetectionPrediction(FaceDetectionPrediction face, float yaw, float pitch)
    {
        this.Face = face;
        this.Yaw = yaw;
        this.Pitch = pitch;
    }
}