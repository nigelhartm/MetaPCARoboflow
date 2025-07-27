using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the StubResponse schema.
/// </summary>
public class StubResponse
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
    /// Field to mark prediction type as stub
    /// </summary>
    [JsonProperty("is_stub")] 
    public bool Is_Stub { get; set; }

    /// <summary>
    /// Identifier of a model stub that was called
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// Task type of the project
    /// </summary>
    [JsonProperty("task_type")] 
    public string Task_Type { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="StubResponse"/>.
    /// </summary>
    /// <param name="is_Stub">The is_Stub.</param>
    /// <param name="model_Id">The model_Id.</param>
    /// <param name="task_Type">The task_Type.</param>
    public StubResponse(bool is_Stub, string model_Id, string task_Type)
    {
        this.Is_Stub = is_Stub;
        this.Model_Id = model_Id;
        this.Task_Type = task_Type;
    }
}