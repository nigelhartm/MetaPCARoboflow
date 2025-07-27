using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ModelsDescriptions schema.
/// </summary>
public class ModelsDescriptions
{
    /// <summary>
    /// List of models that are loaded by model manager.
    /// </summary>
    [JsonProperty("models")] 
    public List<ModelDescriptionEntity> Models { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelsDescriptions"/>.
    /// </summary>
    /// <param name="models">The models.</param>
    public ModelsDescriptions(List<ModelDescriptionEntity> models)
    {
        this.Models = models;
    }
}