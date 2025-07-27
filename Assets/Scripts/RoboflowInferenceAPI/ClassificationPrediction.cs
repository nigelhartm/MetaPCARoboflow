using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Classification prediction.
/// 
/// Attributes:
///     class_name (str): The predicted class label.
///     class_id (int): Numeric ID associated with the class label.
///     confidence (float): The class label confidence as a fraction between 0 and 1.
/// </summary>
public class ClassificationPrediction
{
    /// <summary>
    /// The predicted class label
    /// </summary>
    [JsonProperty("class")] 
    public string Class { get; set; }

    /// <summary>
    /// Numeric ID associated with the class label
    /// </summary>
    [JsonProperty("class_id")] 
    public int Class_Id { get; set; }

    /// <summary>
    /// The class label confidence as a fraction between 0 and 1
    /// </summary>
    [JsonProperty("confidence")] 
    public float Confidence { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ClassificationPrediction"/>.
    /// </summary>
    /// <param name="@class">The @class.</param>
    /// <param name="class_Id">The class_Id.</param>
    /// <param name="confidence">The confidence.</param>
    public ClassificationPrediction(string @class, int class_Id, float confidence)
    {
        this.Class = @class;
        this.Class_Id = class_Id;
        this.Confidence = confidence;
    }
}