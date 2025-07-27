using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the HTTPValidationError schema.
/// </summary>
public class HTTPValidationError
{
    /// <summary>
    /// Gets or sets the detail.
    /// </summary>
    [JsonProperty("detail")] 
    public List<ValidationError> Detail { get; set; }

}