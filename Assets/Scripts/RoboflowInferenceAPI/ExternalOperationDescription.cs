using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ExternalOperationDescription schema.
/// </summary>
public class ExternalOperationDescription
{
    /// <summary>
    /// Gets or sets the operation_type.
    /// </summary>
    [JsonProperty("operation_type")] 
    public string Operation_Type { get; set; }

    /// <summary>
    /// Gets or sets the compound.
    /// </summary>
    [JsonProperty("compound")] 
    public bool Compound { get; set; }

    /// <summary>
    /// Gets or sets the input_kind.
    /// </summary>
    [JsonProperty("input_kind")] 
    public List<string> Input_Kind { get; set; }

    /// <summary>
    /// Gets or sets the output_kind.
    /// </summary>
    [JsonProperty("output_kind")] 
    public List<string> Output_Kind { get; set; }

    /// <summary>
    /// Gets or sets the nested_operation_input_kind.
    /// </summary>
    [JsonProperty("nested_operation_input_kind")] 
    public List<string> Nested_Operation_Input_Kind { get; set; }

    /// <summary>
    /// Gets or sets the nested_operation_output_kind.
    /// </summary>
    [JsonProperty("nested_operation_output_kind")] 
    public List<string> Nested_Operation_Output_Kind { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [JsonProperty("description")] 
    public string Description { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ExternalOperationDescription"/>.
    /// </summary>
    /// <param name="operation_Type">The operation_Type.</param>
    /// <param name="compound">The compound.</param>
    /// <param name="input_Kind">The input_Kind.</param>
    /// <param name="output_Kind">The output_Kind.</param>
    public ExternalOperationDescription(string operation_Type, bool compound, List<string> input_Kind, List<string> output_Kind)
    {
        this.Operation_Type = operation_Type;
        this.Compound = compound;
        this.Input_Kind = input_Kind;
        this.Output_Kind = output_Kind;
    }
}