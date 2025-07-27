using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the Sam2PromptSet schema.
/// </summary>
public class Sam2PromptSet
{
    /// <summary>
    /// An optional list of prompts for masks to predict. Each prompt can include a bounding box and / or a set of postive or negative points
    /// </summary>
    [JsonProperty("prompts")] 
    public List<Sam2Prompt> Prompts { get; set; }

}