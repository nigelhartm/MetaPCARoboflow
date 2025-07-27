using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the InferencePipelineStatusResponse schema.
/// </summary>
public class InferencePipelineStatusResponse
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
    /// Gets or sets the report.
    /// </summary>
    [JsonProperty("report")] 
    public object Report { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InferencePipelineStatusResponse"/>.
    /// </summary>
    /// <param name="status">The status.</param>
    /// <param name="context">The context.</param>
    /// <param name="report">The report.</param>
    public InferencePipelineStatusResponse(string status, CommandContext context, object report)
    {
        this.Status = status;
        this.Context = context;
        this.Report = report;
    }
}