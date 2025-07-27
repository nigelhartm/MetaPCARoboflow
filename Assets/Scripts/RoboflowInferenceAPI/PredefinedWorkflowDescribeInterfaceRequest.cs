using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the PredefinedWorkflowDescribeInterfaceRequest schema.
/// </summary>
public class PredefinedWorkflowDescribeInterfaceRequest
{
    /// <summary>
    /// Roboflow API Key that will be passed to the model during initialization for artifact retrieval
    /// </summary>
    [JsonProperty("api_key")] 
    public string Api_Key { get; set; }

    /// <summary>
    /// Controls usage of cache for workflow definitions. Set this to False when you frequently modify definition saved in Roboflow app and want to fetch the newest version for the request. Only applies for Workflows definitions saved on Roboflow platform.
    /// </summary>
    [JsonProperty("use_cache")] 
    public bool Use_Cache { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="PredefinedWorkflowDescribeInterfaceRequest"/>.
    /// </summary>
    /// <param name="api_Key">The api_Key.</param>
    public PredefinedWorkflowDescribeInterfaceRequest(string api_Key)
    {
        this.Api_Key = api_Key;
    }
}