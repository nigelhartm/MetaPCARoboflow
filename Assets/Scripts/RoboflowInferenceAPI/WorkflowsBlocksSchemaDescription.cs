using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WorkflowsBlocksSchemaDescription schema.
/// </summary>
public class WorkflowsBlocksSchemaDescription
{
    /// <summary>
    /// Schema for validating block definitions
    /// </summary>
    [JsonProperty("schema")] 
    public object Schema { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WorkflowsBlocksSchemaDescription"/>.
    /// </summary>
    /// <param name="schema">The schema.</param>
    public WorkflowsBlocksSchemaDescription(object schema)
    {
        this.Schema = schema;
    }
}