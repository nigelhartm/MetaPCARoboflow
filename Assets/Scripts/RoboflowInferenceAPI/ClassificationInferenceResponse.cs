using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Classification inference response.
/// 
/// Attributes:
///     predictions (List[inference.core.entities.responses.inference.ClassificationPrediction]): List of classification predictions.
///     top (str): The top predicted class label.
///     confidence (float): The confidence of the top predicted class label.
/// </summary>
public class ClassificationInferenceResponse
{
    /// <summary>
    /// Base64 encoded string containing prediction visualization image data
    /// </summary>
    [JsonProperty("visualization")] 
    public string Visualization { get; set; }

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
    /// The time in seconds it took to produce the predictions including image preprocessing
    /// </summary>
    [JsonProperty("time")] 
    public float? Time { get; set; }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    [JsonProperty("image")] 
    //[JsonConverter(typeof(SingleOrArrayConverter<InferenceResponseImage>))]
    //public List<InferenceResponseImage> Image { get; set; }
    public InferenceResponseImage Image { get; set; }

    /// <summary>
    /// Gets or sets the predictions.
    /// </summary>
    [JsonProperty("predictions")] 
    public List<ClassificationPrediction> Predictions { get; set; }

    /// <summary>
    /// The top predicted class label
    /// </summary>
    [JsonProperty("top")] 
    public string Top { get; set; }

    /// <summary>
    /// The confidence of the top predicted class label
    /// </summary>
    [JsonProperty("confidence")] 
    public float Confidence { get; set; }

    /// <summary>
    /// Identifier of parent image region. Useful when stack of detection-models is in use to refer the RoI being the input to inference
    /// </summary>
    [JsonProperty("parent_id")] 
    public string Parent_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ClassificationInferenceResponse"/>.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="predictions">The predictions.</param>
    //public ClassificationInferenceResponse(List<InferenceResponseImage> image, List<ClassificationPrediction> predictions)
    public ClassificationInferenceResponse(InferenceResponseImage image, List<ClassificationPrediction> predictions)
    {
        this.Image = image;
        this.Predictions = predictions;
    }
}