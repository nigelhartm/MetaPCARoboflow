using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the CommandResponse schema.
/// </summary>
public class CommandResponse
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
    /// Initializes a new instance of <see cref="CommandResponse"/>.
    /// </summary>
    /// <param name="status">The status.</param>
    /// <param name="context">The context.</param>
    public CommandResponse(string status, CommandContext context)
    {
        this.Status = status;
        this.Context = context;
    }
}