using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ConsumePipelineResponse schema.
/// </summary>
public class ConsumePipelineResponse
{
    /// <summary>
    /// Operation status
    /// </summary>
    [JsonProperty("status")] 
    public string Status { get; set; }

    /// <summary>
    /// Context of the command.
    /// </summary>
    [JsonProperty("context")] 
    public CommandContext Context { get; set; }

    /// <summary>
    /// Gets or sets the outputs.
    /// </summary>
    [JsonProperty("outputs")] 
    public List<object> Outputs { get; set; }

    /// <summary>
    /// Gets or sets the frames_metadata.
    /// </summary>
    [JsonProperty("frames_metadata")] 
    public List<FrameMetadata> Frames_Metadata { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ConsumePipelineResponse"/>.
    /// </summary>
    /// <param name="status">The status.</param>
    /// <param name="context">The context.</param>
    /// <param name="outputs">The outputs.</param>
    /// <param name="frames_Metadata">The frames_Metadata.</param>
    public ConsumePipelineResponse(string status, CommandContext context, List<object> outputs, List<FrameMetadata> frames_Metadata)
    {
        this.Status = status;
        this.Context = context;
        this.Outputs = outputs;
        this.Frames_Metadata = frames_Metadata;
    }
}