using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the UniversalQueryLanguageDescription schema.
/// </summary>
public class UniversalQueryLanguageDescription
{
    /// <summary>
    /// Gets or sets the operations_description.
    /// </summary>
    [JsonProperty("operations_description")] 
    public List<ExternalOperationDescription> Operations_Description { get; set; }

    /// <summary>
    /// Gets or sets the operators_descriptions.
    /// </summary>
    [JsonProperty("operators_descriptions")] 
    public List<ExternalOperatorDescription> Operators_Descriptions { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="UniversalQueryLanguageDescription"/>.
    /// </summary>
    /// <param name="operations_Description">The operations_Description.</param>
    /// <param name="operators_Descriptions">The operators_Descriptions.</param>
    public UniversalQueryLanguageDescription(List<ExternalOperationDescription> operations_Description, List<ExternalOperatorDescription> operators_Descriptions)
    {
        this.Operations_Description = operations_Description;
        this.Operators_Descriptions = operators_Descriptions;
    }
}