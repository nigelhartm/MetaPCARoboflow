using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// OCR Inference response.
/// 
/// Attributes:
///     result (str): The OCR recognition result.
///     time: The time in seconds it took to produce the inference including preprocessing.
/// </summary>
public class OCRInferenceResponse
{
    /// <summary>
    /// The OCR recognition result.
    /// </summary>
    [JsonProperty("result")] 
    public string Result { get; set; }

    /// <summary>
    /// The time in seconds it took to produce the inference including preprocessing.
    /// </summary>
    [JsonProperty("time")] 
    public float Time { get; set; }

    /// <summary>
    /// Identifier of parent image region. Useful when stack of detection-models is in use to refer the RoI being the input to inference
    /// </summary>
    [JsonProperty("parent_id")] 
    public string Parent_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="OCRInferenceResponse"/>.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <param name="time">The time.</param>
    public OCRInferenceResponse(string result, float time)
    {
        this.Result = result;
        this.Time = time;
    }
}