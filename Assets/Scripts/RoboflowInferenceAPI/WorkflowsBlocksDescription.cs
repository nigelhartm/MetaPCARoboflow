using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WorkflowsBlocksDescription schema.
/// </summary>
public class WorkflowsBlocksDescription
{
    /// <summary>
    /// List of loaded blocks descriptions
    /// </summary>
    [JsonProperty("blocks")] 
    public List<BlockDescription> Blocks { get; set; }

    /// <summary>
    /// List of kinds defined for blocks
    /// </summary>
    [JsonProperty("declared_kinds")] 
    public List<Kind> Declared_Kinds { get; set; }

    /// <summary>
    /// Mapping from kind name into list of blocks properties accepting references of that kind
    /// </summary>
    [JsonProperty("kinds_connections")] 
    public object Kinds_Connections { get; set; }

    /// <summary>
    /// List defining all properties for all blocks that can be filled with primitive values in workflow definition.
    /// </summary>
    [JsonProperty("primitives_connections")] 
    public List<ExternalBlockPropertyPrimitiveDefinition> Primitives_Connections { get; set; }

    /// <summary>
    /// Definitions of Universal Query Language operations and operators
    /// </summary>
    [JsonProperty("universal_query_language_description")] 
    public UniversalQueryLanguageDescription Universal_Query_Language_Description { get; set; }

    /// <summary>
    /// Schema for dynamic block definition
    /// </summary>
    [JsonProperty("dynamic_block_definition_schema")] 
    public object Dynamic_Block_Definition_Schema { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WorkflowsBlocksDescription"/>.
    /// </summary>
    /// <param name="blocks">The blocks.</param>
    /// <param name="declared_Kinds">The declared_Kinds.</param>
    /// <param name="kinds_Connections">The kinds_Connections.</param>
    /// <param name="primitives_Connections">The primitives_Connections.</param>
    /// <param name="universal_Query_Language_Description">The universal_Query_Language_Description.</param>
    /// <param name="dynamic_Block_Definition_Schema">The dynamic_Block_Definition_Schema.</param>
    public WorkflowsBlocksDescription(List<BlockDescription> blocks, List<Kind> declared_Kinds, object kinds_Connections, List<ExternalBlockPropertyPrimitiveDefinition> primitives_Connections, UniversalQueryLanguageDescription universal_Query_Language_Description, object dynamic_Block_Definition_Schema)
    {
        this.Blocks = blocks;
        this.Declared_Kinds = declared_Kinds;
        this.Kinds_Connections = kinds_Connections;
        this.Primitives_Connections = primitives_Connections;
        this.Universal_Query_Language_Description = universal_Query_Language_Description;
        this.Dynamic_Block_Definition_Schema = dynamic_Block_Definition_Schema;
    }
}