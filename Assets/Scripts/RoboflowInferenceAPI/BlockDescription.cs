using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the BlockDescription schema.
/// </summary>
public class BlockDescription
{
    /// <summary>
    /// OpenAPI specification of block manifest that can be used to create workflow step in JSON definition.
    /// </summary>
    [JsonProperty("block_schema")] 
    public object Block_Schema { get; set; }

    /// <summary>
    /// Definition of step outputs and their kinds
    /// </summary>
    [JsonProperty("outputs_manifest")] 
    public List<OutputDefinition> Outputs_Manifest { get; set; }

    /// <summary>
    /// Name of source plugin that defines block
    /// </summary>
    [JsonProperty("block_source")] 
    public string Block_Source { get; set; }

    /// <summary>
    /// Fully qualified class name of block implementation.
    /// </summary>
    [JsonProperty("fully_qualified_block_class_name")] 
    public string Fully_Qualified_Block_Class_Name { get; set; }

    /// <summary>
    /// Field generated based on class name providing human-friendly name of the block.
    /// </summary>
    [JsonProperty("human_friendly_block_name")] 
    public string Human_Friendly_Block_Name { get; set; }

    /// <summary>
    /// Field holds value that is used to recognise block manifest while parsing `workflow` JSON definition.
    /// </summary>
    [JsonProperty("manifest_type_identifier")] 
    public string Manifest_Type_Identifier { get; set; }

    /// <summary>
    /// Aliases of `manifest_type_identifier` that are in use.
    /// </summary>
    [JsonProperty("manifest_type_identifier_aliases")] 
    public List<string> Manifest_Type_Identifier_Aliases { get; set; }

    /// <summary>
    /// Execution Engine versions compatible with block.
    /// </summary>
    [JsonProperty("execution_engine_compatibility")] 
    public string Execution_Engine_Compatibility { get; set; }

    /// <summary>
    /// Dimensionality offsets for input parameters
    /// </summary>
    [JsonProperty("input_dimensionality_offsets")] 
    public object Input_Dimensionality_Offsets { get; set; }

    /// <summary>
    /// Selected dimensionality reference property provided if different dimensionality for different inputs are supported.
    /// </summary>
    [JsonProperty("dimensionality_reference_property")] 
    public string Dimensionality_Reference_Property { get; set; }

    /// <summary>
    /// Dimensionality offset for block output.
    /// </summary>
    [JsonProperty("output_dimensionality_offset")] 
    public int Output_Dimensionality_Offset { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="BlockDescription"/>.
    /// </summary>
    /// <param name="block_Schema">The block_Schema.</param>
    /// <param name="outputs_Manifest">The outputs_Manifest.</param>
    /// <param name="block_Source">The block_Source.</param>
    /// <param name="fully_Qualified_Block_Class_Name">The fully_Qualified_Block_Class_Name.</param>
    /// <param name="human_Friendly_Block_Name">The human_Friendly_Block_Name.</param>
    /// <param name="manifest_Type_Identifier">The manifest_Type_Identifier.</param>
    /// <param name="input_Dimensionality_Offsets">The input_Dimensionality_Offsets.</param>
    /// <param name="dimensionality_Reference_Property">The dimensionality_Reference_Property.</param>
    /// <param name="output_Dimensionality_Offset">The output_Dimensionality_Offset.</param>
    public BlockDescription(object block_Schema, List<OutputDefinition> outputs_Manifest, string block_Source, string fully_Qualified_Block_Class_Name, string human_Friendly_Block_Name, string manifest_Type_Identifier, object input_Dimensionality_Offsets, string dimensionality_Reference_Property, int output_Dimensionality_Offset)
    {
        this.Block_Schema = block_Schema;
        this.Outputs_Manifest = outputs_Manifest;
        this.Block_Source = block_Source;
        this.Fully_Qualified_Block_Class_Name = fully_Qualified_Block_Class_Name;
        this.Human_Friendly_Block_Name = human_Friendly_Block_Name;
        this.Manifest_Type_Identifier = manifest_Type_Identifier;
        this.Input_Dimensionality_Offsets = input_Dimensionality_Offsets;
        this.Dimensionality_Reference_Property = dimensionality_Reference_Property;
        this.Output_Dimensionality_Offset = output_Dimensionality_Offset;
    }
}