using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ManifestDescription schema.
/// </summary>
public class ManifestDescription
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Field holds type of the bock to be dynamically created. Block can be initialised as step using the type declared in the field.
    /// </summary>
    [JsonProperty("block_type")] 
    public string Block_Type { get; set; }

    /// <summary>
    /// Description of the block to be used in manifest
    /// </summary>
    [JsonProperty("description")] 
    public string Description { get; set; }

    /// <summary>
    /// Mapping name -> input definition for block inputs (parameters for run() function ofdynamic block)
    /// </summary>
    [JsonProperty("inputs")] 
    public object Inputs { get; set; }

    /// <summary>
    /// Mapping name -> output kind for block outputs.
    /// </summary>
    [JsonProperty("outputs")] 
    public object Outputs { get; set; }

    /// <summary>
    /// Definition of output dimensionality offset
    /// </summary>
    [JsonProperty("output_dimensionality_offset")] 
    public int Output_Dimensionality_Offset { get; set; }

    /// <summary>
    /// Flag to decide if function will be provided with batch data as whole or with singular batch elements while execution
    /// </summary>
    [JsonProperty("accepts_batch_input")] 
    public bool Accepts_Batch_Input { get; set; }

    /// <summary>
    /// Flag to decide if empty (optional) values will be shipped as run() function parameters
    /// </summary>
    [JsonProperty("accepts_empty_values")] 
    public bool Accepts_Empty_Values { get; set; }

    /// <summary>
    /// List of batch-oriented parameters. Value will override `accepts_batch_input` if non-empty list is provided, `accepts_batch_input` is  kept not to break backward compatibility.
    /// </summary>
    [JsonProperty("batch_oriented_parameters")] 
    public List<string> Batch_Oriented_Parameters { get; set; }

    /// <summary>
    /// List of parameters accepting both batches and scalars at the same time. Value will override `accepts_batch_input` if non-empty list is provided, `accepts_batch_input` is kept not to break backward compatibility.
    /// </summary>
    [JsonProperty("parameters_with_scalars_and_batches")] 
    public List<string> Parameters_With_Scalars_And_Batches { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ManifestDescription"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="block_Type">The block_Type.</param>
    /// <param name="inputs">The inputs.</param>
    public ManifestDescription(string type, string block_Type, object inputs)
    {
        this.Type = type;
        this.Block_Type = block_Type;
        this.Inputs = inputs;
    }
}