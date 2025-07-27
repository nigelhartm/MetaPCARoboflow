using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request to clear a model from the inference server.
/// 
/// Attributes:
///     model_id (str): A unique model identifier.
/// </summary>
public class ClearModelRequest
{
    /// <summary>
    /// A unique model identifier
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ClearModelRequest"/>.
    /// </summary>
    /// <param name="model_Id">The model_Id.</param>
    public ClearModelRequest(string model_Id)
    {
        this.Model_Id = model_Id;
    }
}