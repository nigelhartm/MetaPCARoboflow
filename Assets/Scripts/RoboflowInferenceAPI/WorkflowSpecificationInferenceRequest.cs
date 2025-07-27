using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WorkflowSpecificationInferenceRequest schema.
/// </summary>
public class WorkflowSpecificationInferenceRequest
{
    /// <summary>
    /// Roboflow API Key that will be passed to the model during initialization for artifact retrieval
    /// </summary>
    [JsonProperty("api_key")] 
    public string Api_Key { get; set; }

    /// <summary>
    /// Dictionary that contains each parameter defined as an input for chosen workflow
    /// </summary>
    [JsonProperty("inputs")] 
    public object Inputs { get; set; }

    /// <summary>
    /// List of field that shall be excluded from the response (among those defined in workflow specification)
    /// </summary>
    [JsonProperty("excluded_fields")] 
    public List<string> Excluded_Fields { get; set; }

    /// <summary>
    /// Flag to request Workflow run profiling. Enables Workflow profiler only when server settings allow profiling traces to be exported to clients. Only applies for Workflows definitions saved on Roboflow platform.
    /// </summary>
    [JsonProperty("enable_profiling")] 
    public bool Enable_Profiling { get; set; }

    /// <summary>
    /// Optional identifier of workflow
    /// </summary>
    [JsonProperty("workflow_id")] 
    public string Workflow_Id { get; set; }

    /// <summary>
    /// Gets or sets the specification.
    /// </summary>
    [JsonProperty("specification")] 
    public object Specification { get; set; }

    /// <summary>
    /// Reserved, used internally by Roboflow to distinguish between preview and non-preview runs
    /// </summary>
    [JsonProperty("is_preview")] 
    public bool Is_Preview { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WorkflowSpecificationInferenceRequest"/>.
    /// </summary>
    /// <param name="inputs">The inputs.</param>
    /// <param name="specification">The specification.</param>
    public WorkflowSpecificationInferenceRequest(object inputs, object specification)
    {
        this.Inputs = inputs;
        this.Specification = specification;
    }
}