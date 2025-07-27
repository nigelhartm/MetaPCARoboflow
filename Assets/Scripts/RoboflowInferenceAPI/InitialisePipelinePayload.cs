using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the InitialisePipelinePayload schema.
/// </summary>
public class InitialisePipelinePayload
{
    /// <summary>
    /// Gets or sets the video_configuration.
    /// </summary>
    [JsonProperty("video_configuration")] 
    public VideoConfiguration Video_Configuration { get; set; }

    /// <summary>
    /// Gets or sets the processing_configuration.
    /// </summary>
    [JsonProperty("processing_configuration")] 
    public WorkflowConfiguration Processing_Configuration { get; set; }

    /// <summary>
    /// Gets or sets the sink_configuration.
    /// </summary>
    [JsonProperty("sink_configuration")] 
    public MemorySinkConfiguration Sink_Configuration { get; set; }

    /// <summary>
    /// Gets or sets the consumption_timeout.
    /// </summary>
    [JsonProperty("consumption_timeout")] 
    public float? Consumption_Timeout { get; set; }

    /// <summary>
    /// Gets or sets the api_key.
    /// </summary>
    [JsonProperty("api_key")] 
    public string Api_Key { get; set; }

    /// <summary>
    /// Gets or sets the predictions_queue_size.
    /// </summary>
    [JsonProperty("predictions_queue_size")] 
    public int Predictions_Queue_Size { get; set; }

    /// <summary>
    /// Gets or sets the decoding_buffer_size.
    /// </summary>
    [JsonProperty("decoding_buffer_size")] 
    public int Decoding_Buffer_Size { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InitialisePipelinePayload"/>.
    /// </summary>
    /// <param name="video_Configuration">The video_Configuration.</param>
    /// <param name="processing_Configuration">The processing_Configuration.</param>
    public InitialisePipelinePayload(VideoConfiguration video_Configuration, WorkflowConfiguration processing_Configuration)
    {
        this.Video_Configuration = video_Configuration;
        this.Processing_Configuration = processing_Configuration;
    }
}