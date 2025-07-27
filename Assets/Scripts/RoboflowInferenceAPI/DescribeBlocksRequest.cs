using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the DescribeBlocksRequest schema.
/// </summary>
public class DescribeBlocksRequest
{
    /// <summary>
    /// Dynamic blocks to be used.
    /// </summary>
    [JsonProperty("dynamic_blocks_definitions")] 
    public List<DynamicBlockDefinition> Dynamic_Blocks_Definitions { get; set; }

    /// <summary>
    /// Requested Execution Engine compatibility. If given, result will only contain blocks suitable for requested EE version, otherwise - descriptions for all available blocks will be delivered.
    /// </summary>
    [JsonProperty("execution_engine_version")] 
    public string Execution_Engine_Version { get; set; }

}