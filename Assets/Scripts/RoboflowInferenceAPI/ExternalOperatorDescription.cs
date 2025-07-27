using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ExternalOperatorDescription schema.
/// </summary>
public class ExternalOperatorDescription
{
    /// <summary>
    /// Gets or sets the operator_type.
    /// </summary>
    [JsonProperty("operator_type")] 
    public string Operator_Type { get; set; }

    /// <summary>
    /// Gets or sets the operands_number.
    /// </summary>
    [JsonProperty("operands_number")] 
    public int Operands_Number { get; set; }

    /// <summary>
    /// Gets or sets the operands_kinds.
    /// </summary>
    [JsonProperty("operands_kinds")] 
    public List<List<string>> Operands_Kinds { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [JsonProperty("description")] 
    public string Description { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ExternalOperatorDescription"/>.
    /// </summary>
    /// <param name="operator_Type">The operator_Type.</param>
    /// <param name="operands_Number">The operands_Number.</param>
    /// <param name="operands_Kinds">The operands_Kinds.</param>
    public ExternalOperatorDescription(string operator_Type, int operands_Number, List<List<string>> operands_Kinds)
    {
        this.Operator_Type = operator_Type;
        this.Operands_Number = operands_Number;
        this.Operands_Kinds = operands_Kinds;
    }
}