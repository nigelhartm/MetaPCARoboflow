using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Request to add a model to the inference server.
/// 
/// Attributes:
///     model_id (str): A unique model identifier.
///     model_type (Optional[str]): The type of the model, usually referring to what task the model performs.
///     api_key (Optional[str]): Roboflow API Key that will be passed to the model during initialization for artifact retrieval.
/// </summary>
public class AddModelRequest
{
    /// <summary>
    /// A unique model identifier
    /// </summary>
    [JsonProperty("model_id")] 
    public string Model_Id { get; set; }

    /// <summary>
    /// The type of the model, usually referring to what task the model performs
    /// </summary>
    [JsonProperty("model_type")] 
    public string Model_Type { get; set; }

    /// <summary>
    /// Roboflow API Key that will be passed to the model during initialization for artifact retrieval
    /// </summary>
    [JsonProperty("api_key")] 
    public string Api_Key { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="AddModelRequest"/>.
    /// </summary>
    /// <param name="model_Id">The model_Id.</param>
    public AddModelRequest(string model_Id)
    {
        this.Model_Id = model_Id;
    }
}