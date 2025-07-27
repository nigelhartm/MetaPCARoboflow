using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the InitialiseWebRTCPipelinePayload schema.
/// </summary>
public class InitialiseWebRTCPipelinePayload
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
    /// Gets or sets the webrtc_offer.
    /// </summary>
    [JsonProperty("webrtc_offer")] 
    public WebRTCOffer Webrtc_Offer { get; set; }

    /// <summary>
    /// Gets or sets the webrtc_turn_config.
    /// </summary>
    [JsonProperty("webrtc_turn_config")] 
    public WebRTCTURNConfig Webrtc_Turn_Config { get; set; }

    /// <summary>
    /// Gets or sets the stream_output.
    /// </summary>
    [JsonProperty("stream_output")] 
    public List<string> Stream_Output { get; set; }

    /// <summary>
    /// Gets or sets the data_output.
    /// </summary>
    [JsonProperty("data_output")] 
    public List<string> Data_Output { get; set; }

    /// <summary>
    /// Gets or sets the webrtc_peer_timeout.
    /// </summary>
    [JsonProperty("webrtc_peer_timeout")] 
    public float Webrtc_Peer_Timeout { get; set; }

    /// <summary>
    /// Gets or sets the webcam_fps.
    /// </summary>
    [JsonProperty("webcam_fps")] 
    public float? Webcam_Fps { get; set; }

    /// <summary>
    /// Gets or sets the processing_timeout.
    /// </summary>
    [JsonProperty("processing_timeout")] 
    public float Processing_Timeout { get; set; }

    /// <summary>
    /// Gets or sets the fps_probe_frames.
    /// </summary>
    [JsonProperty("fps_probe_frames")] 
    public int Fps_Probe_Frames { get; set; }

    /// <summary>
    /// Gets or sets the max_consecutive_timeouts.
    /// </summary>
    [JsonProperty("max_consecutive_timeouts")] 
    public int Max_Consecutive_Timeouts { get; set; }

    /// <summary>
    /// Gets or sets the min_consecutive_on_time.
    /// </summary>
    [JsonProperty("min_consecutive_on_time")] 
    public int Min_Consecutive_On_Time { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InitialiseWebRTCPipelinePayload"/>.
    /// </summary>
    /// <param name="video_Configuration">The video_Configuration.</param>
    /// <param name="processing_Configuration">The processing_Configuration.</param>
    /// <param name="webrtc_Offer">The webrtc_Offer.</param>
    public InitialiseWebRTCPipelinePayload(VideoConfiguration video_Configuration, WorkflowConfiguration processing_Configuration, WebRTCOffer webrtc_Offer)
    {
        this.Video_Configuration = video_Configuration;
        this.Processing_Configuration = processing_Configuration;
        this.Webrtc_Offer = webrtc_Offer;
    }
}