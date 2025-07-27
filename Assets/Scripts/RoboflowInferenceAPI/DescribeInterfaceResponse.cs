using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the DescribeInterfaceResponse schema.
/// </summary>
public class DescribeInterfaceResponse
{
    /// <summary>
    /// Dictionary mapping Workflow inputs to their kinds
    /// </summary>
    [JsonProperty("inputs")] 
    public object Inputs { get; set; }

    /// <summary>
    /// Dictionary mapping Workflow outputs to their kinds
    /// </summary>
    [JsonProperty("outputs")] 
    public object Outputs { get; set; }

    /// <summary>
    /// Dictionary mapping name of the kind with Python typing hint for underlying serialised object
    /// </summary>
    [JsonProperty("typing_hints")] 
    public object Typing_Hints { get; set; }

    /// <summary>
    /// Dictionary mapping name of the kind with OpenAPI 3.0 definitions of underlying objects. If list is given, entity should be treated as union of types.
    /// </summary>
    [JsonProperty("kinds_schemas")] 
    public object Kinds_Schemas { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="DescribeInterfaceResponse"/>.
    /// </summary>
    /// <param name="inputs">The inputs.</param>
    /// <param name="outputs">The outputs.</param>
    /// <param name="typing_Hints">The typing_Hints.</param>
    /// <param name="kinds_Schemas">The kinds_Schemas.</param>
    public DescribeInterfaceResponse(object inputs, object outputs, object typing_Hints, object kinds_Schemas)
    {
        this.Inputs = inputs;
        this.Outputs = outputs;
        this.Typing_Hints = typing_Hints;
        this.Kinds_Schemas = kinds_Schemas;
    }
}