using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ModelDescriptionEntity schema.
/// </summary>
public class ModelDescriptionEntity
{
    /// <summary>
    /// Identifier of the model
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// Type of the task that the model performs
    /// </summary>
    [JsonProperty("task_type")] 
    public string Task_Type { get; set; }

    /// <summary>
    /// Batch size accepted by the model (if registered).
    /// </summary>
    [JsonProperty("batch_size")] 
    public int? Batch_Size { get; set; }

    /// <summary>
    /// Image input height accepted by the model (if registered).
    /// </summary>
    [JsonProperty("input_height")] 
    public int? Input_Height { get; set; }

    /// <summary>
    /// Image input width accepted by the model (if registered).
    /// </summary>
    [JsonProperty("input_width")] 
    public int? Input_Width { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelDescriptionEntity"/>.
    /// </summary>
    /// <param name="model_Id">The model_Id.</param>
    /// <param name="task_Type">The task_Type.</param>
    public ModelDescriptionEntity(string model_Id, string task_Type)
    {
        this.Model_Id = model_Id;
        this.Task_Type = task_Type;
    }
}