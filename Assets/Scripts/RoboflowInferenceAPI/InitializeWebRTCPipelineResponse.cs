using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the InitializeWebRTCPipelineResponse schema.
/// </summary>
public class InitializeWebRTCPipelineResponse
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
    /// Gets or sets the sdp.
    /// </summary>
    [JsonProperty("sdp")] 
    public string Sdp { get; set; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InitializeWebRTCPipelineResponse"/>.
    /// </summary>
    /// <param name="status">The status.</param>
    /// <param name="context">The context.</param>
    /// <param name="sdp">The sdp.</param>
    /// <param name="type">The type.</param>
    public InitializeWebRTCPipelineResponse(string status, CommandContext context, string sdp, string type)
    {
        this.Status = status;
        this.Context = context;
        this.Sdp = sdp;
        this.Type = type;
    }
}