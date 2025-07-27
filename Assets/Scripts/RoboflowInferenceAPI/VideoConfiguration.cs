using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the VideoConfiguration schema.
/// </summary>
public class VideoConfiguration
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the video_reference.
    /// </summary>
    [JsonProperty("video_reference")] 
    public int? Video_Reference { get; set; }

    /// <summary>
    /// Gets or sets the max_fps.
    /// </summary>
    [JsonProperty("max_fps")] 
    public float? Max_Fps { get; set; }

    /// <summary>
    /// Gets or sets the source_buffer_filling_strategy.
    /// </summary>
    [JsonProperty("source_buffer_filling_strategy")] 
    public BufferFillingStrategy Source_Buffer_Filling_Strategy { get; set; }

    /// <summary>
    /// Gets or sets the source_buffer_consumption_strategy.
    /// </summary>
    [JsonProperty("source_buffer_consumption_strategy")] 
    public BufferConsumptionStrategy Source_Buffer_Consumption_Strategy { get; set; }

    /// <summary>
    /// Gets or sets the video_source_properties.
    /// </summary>
    [JsonProperty("video_source_properties")] 
    public object Video_Source_Properties { get; set; }

    /// <summary>
    /// Gets or sets the batch_collection_timeout.
    /// </summary>
    [JsonProperty("batch_collection_timeout")] 
    public float? Batch_Collection_Timeout { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="VideoConfiguration"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="video_Reference">The video_Reference.</param>
    public VideoConfiguration(string type, int? video_Reference)
    {
        this.Type = type;
        this.Video_Reference = video_Reference;
    }
}