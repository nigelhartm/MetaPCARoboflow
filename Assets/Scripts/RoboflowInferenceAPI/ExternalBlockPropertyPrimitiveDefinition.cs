using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ExternalBlockPropertyPrimitiveDefinition schema.
/// </summary>
public class ExternalBlockPropertyPrimitiveDefinition
{
    /// <summary>
    /// Identifier of block
    /// </summary>
    [JsonProperty("manifest_type_identifier")] 
    public string Manifest_Type_Identifier { get; set; }

    /// <summary>
    /// Name of specific property
    /// </summary>
    [JsonProperty("property_name")] 
    public string Property_Name { get; set; }

    /// <summary>
    /// Description for specific property
    /// </summary>
    [JsonProperty("property_description")] 
    public string Property_Description { get; set; }

    /// <summary>
    /// Pythonic type annotation for property
    /// </summary>
    [JsonProperty("type_annotation")] 
    public string Type_Annotation { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ExternalBlockPropertyPrimitiveDefinition"/>.
    /// </summary>
    /// <param name="manifest_Type_Identifier">The manifest_Type_Identifier.</param>
    /// <param name="property_Name">The property_Name.</param>
    /// <param name="property_Description">The property_Description.</param>
    /// <param name="type_Annotation">The type_Annotation.</param>
    public ExternalBlockPropertyPrimitiveDefinition(string manifest_Type_Identifier, string property_Name, string property_Description, string type_Annotation)
    {
        this.Manifest_Type_Identifier = manifest_Type_Identifier;
        this.Property_Name = property_Name;
        this.Property_Description = property_Description;
        this.Type_Annotation = type_Annotation;
    }
}