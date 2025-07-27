using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ConsumeResultsPayload schema.
/// </summary>
public class ConsumeResultsPayload
{
    /// <summary>
    /// List of workflow output fields to be filtered out from response
    /// </summary>
    [JsonProperty("excluded_fields")] 
    public List<string> Excluded_Fields { get; set; }

}