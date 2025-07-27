using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WorkflowValidationStatus schema.
/// </summary>
public class WorkflowValidationStatus
{
    /// <summary>
    /// Represents validation status
    /// </summary>
    [JsonProperty("status")] 
    public string Status { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WorkflowValidationStatus"/>.
    /// </summary>
    /// <param name="status">The status.</param>
    public WorkflowValidationStatus(string status)
    {
        this.Status = status;
    }
}