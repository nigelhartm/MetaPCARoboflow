using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ListPipelinesResponse schema.
/// </summary>
public class ListPipelinesResponse
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
    /// List IDs of active pipelines
    /// </summary>
    [JsonProperty("pipelines")] 
    public List<string> Pipelines { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ListPipelinesResponse"/>.
    /// </summary>
    /// <param name="status">The status.</param>
    /// <param name="context">The context.</param>
    /// <param name="pipelines">The pipelines.</param>
    public ListPipelinesResponse(string status, CommandContext context, List<string> pipelines)
    {
        this.Status = status;
        this.Context = context;
        this.Pipelines = pipelines;
    }
}