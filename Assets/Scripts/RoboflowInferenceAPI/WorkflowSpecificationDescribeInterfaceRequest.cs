using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WorkflowSpecificationDescribeInterfaceRequest schema.
/// </summary>
public class WorkflowSpecificationDescribeInterfaceRequest
{
    /// <summary>
    /// Roboflow API Key that will be passed to the model during initialization for artifact retrieval
    /// </summary>
    [JsonProperty("api_key")] 
    public string Api_Key { get; set; }

    /// <summary>
    /// Gets or sets the specification.
    /// </summary>
    [JsonProperty("specification")] 
    public object Specification { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WorkflowSpecificationDescribeInterfaceRequest"/>.
    /// </summary>
    /// <param name="api_Key">The api_Key.</param>
    /// <param name="specification">The specification.</param>
    public WorkflowSpecificationDescribeInterfaceRequest(string api_Key, object specification)
    {
        this.Api_Key = api_Key;
        this.Specification = specification;
    }
}