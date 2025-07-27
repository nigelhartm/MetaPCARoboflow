using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ExternalWorkflowsBlockSelectorDefinition schema.
/// </summary>
public class ExternalWorkflowsBlockSelectorDefinition
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
    /// Defines to what type of object (step_output, parameter, etc) reference may be pointing
    /// </summary>
    [JsonProperty("compatible_element")] 
    public string Compatible_Element { get; set; }

    /// <summary>
    /// Boolean flag defining if list of references will be accepted
    /// </summary>
    [JsonProperty("is_list_element")] 
    public bool Is_List_Element { get; set; }

    /// <summary>
    /// Boolean flag defining if dict of references will be accepted
    /// </summary>
    [JsonProperty("is_dict_element")] 
    public bool Is_Dict_Element { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ExternalWorkflowsBlockSelectorDefinition"/>.
    /// </summary>
    /// <param name="manifest_Type_Identifier">The manifest_Type_Identifier.</param>
    /// <param name="property_Name">The property_Name.</param>
    /// <param name="property_Description">The property_Description.</param>
    /// <param name="compatible_Element">The compatible_Element.</param>
    /// <param name="is_List_Element">The is_List_Element.</param>
    /// <param name="is_Dict_Element">The is_Dict_Element.</param>
    public ExternalWorkflowsBlockSelectorDefinition(string manifest_Type_Identifier, string property_Name, string property_Description, string compatible_Element, bool is_List_Element, bool is_Dict_Element)
    {
        this.Manifest_Type_Identifier = manifest_Type_Identifier;
        this.Property_Name = property_Name;
        this.Property_Description = property_Description;
        this.Compatible_Element = compatible_Element;
        this.Is_List_Element = is_List_Element;
        this.Is_Dict_Element = is_Dict_Element;
    }
}