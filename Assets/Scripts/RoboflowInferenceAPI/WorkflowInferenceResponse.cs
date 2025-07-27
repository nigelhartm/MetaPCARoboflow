using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WorkflowInferenceResponse schema.
/// </summary>
public class WorkflowInferenceResponse
{
    /// <summary>
    /// Dictionary with keys defined in workflow output and serialised values
    /// </summary>
    [JsonProperty("outputs")] 
    public List<object> Outputs { get; set; }

    /// <summary>
    /// Profiler events
    /// </summary>
    [JsonProperty("profiler_trace")] 
    public List<object> Profiler_Trace { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WorkflowInferenceResponse"/>.
    /// </summary>
    /// <param name="outputs">The outputs.</param>
    public WorkflowInferenceResponse(List<object> outputs)
    {
        this.Outputs = outputs;
    }
}