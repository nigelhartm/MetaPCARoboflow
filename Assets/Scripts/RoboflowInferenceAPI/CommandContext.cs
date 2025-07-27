using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the CommandContext schema.
/// </summary>
public class CommandContext
{
    /// <summary>
    /// Server-side request ID
    /// </summary>
    [JsonProperty("request_id")] 
    public string Request_Id { get; set; }

    /// <summary>
    /// Identifier of pipeline connected to operation
    /// </summary>
    [JsonProperty("pipeline_id")] 
    public string Pipeline_Id { get; set; }

}