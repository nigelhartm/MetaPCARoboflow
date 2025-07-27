using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the DynamicInputDefinition schema.
/// </summary>
public class DynamicInputDefinition
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Flag to decide if default value is provided for input
    /// </summary>
    [JsonProperty("has_default_value")] 
    public bool Has_Default_Value { get; set; }

    /// <summary>
    /// Definition of default value for a field. Use in combination with, `has_default_value` to decide on default value if field is optional.
    /// </summary>
    [JsonProperty("default_value")] 
    public object Default_Value { get; set; }

    /// <summary>
    /// Flag deciding if `default_value` will be added for manifest field annotation.
    /// </summary>
    [JsonProperty("is_optional")] 
    public bool Is_Optional { get; set; }

    /// <summary>
    /// Flag deciding if declared property holds dimensionality reference - see how dimensionality works for statically defined blocks to discover meaning of the parameter.
    /// </summary>
    [JsonProperty("is_dimensionality_reference")] 
    public bool Is_Dimensionality_Reference { get; set; }

    /// <summary>
    /// Accepted dimensionality offset for parameter. Dimensionality works the same as for traditional workflows blocks.
    /// </summary>
    [JsonProperty("dimensionality_offset")] 
    public int Dimensionality_Offset { get; set; }

    /// <summary>
    /// Union of selector types accepted by input. Should be empty if field does not accept selectors.
    /// </summary>
    [JsonProperty("selector_types")] 
    public List<SelectorType> Selector_Types { get; set; }

    /// <summary>
    /// Mapping of `selector_types` into names of kinds to be compatible. Empty dict (default value) means wildcard kind for all selectors. If name of kind given - must be valid kind, known for workflow execution engine.
    /// </summary>
    [JsonProperty("selector_data_kind")] 
    public object Selector_Data_Kind { get; set; }

    /// <summary>
    /// List of types representing union of types for static values (non selectors) that shall be accepted for input field. Empty list represents no value types allowed.
    /// </summary>
    [JsonProperty("value_types")] 
    public List<ValueType> Value_Types { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="DynamicInputDefinition"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    public DynamicInputDefinition(string type)
    {
        this.Type = type;
    }
}