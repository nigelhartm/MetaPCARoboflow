using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Multi-label Classification prediction.
/// 
/// Attributes:
///     confidence (float): The class label confidence as a fraction between 0 and 1.
/// </summary>
public class MultiLabelClassificationPrediction
{
    /// <summary>
    /// The class label confidence as a fraction between 0 and 1
    /// </summary>
    [JsonProperty("confidence")] 
    public float Confidence { get; set; }

    /// <summary>
    /// Numeric ID associated with the class label
    /// </summary>
    [JsonProperty("class_id")] 
    public int Class_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="MultiLabelClassificationPrediction"/>.
    /// </summary>
    /// <param name="confidence">The confidence.</param>
    /// <param name="class_Id">The class_Id.</param>
    public MultiLabelClassificationPrediction(float confidence, int class_Id)
    {
        this.Confidence = confidence;
        this.Class_Id = class_Id;
    }
}