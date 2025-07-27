using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the FrameMetadata schema.
/// </summary>
public class FrameMetadata
{
    /// <summary>
    /// Gets or sets the frame_timestamp.
    /// </summary>
    [JsonProperty("frame_timestamp")] 
    public string Frame_Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the frame_id.
    /// </summary>
    [JsonProperty("frame_id")] 
    public int Frame_Id { get; set; }

    /// <summary>
    /// Gets or sets the source_id.
    /// </summary>
    [JsonProperty("source_id")] 
    public int? Source_Id { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="FrameMetadata"/>.
    /// </summary>
    /// <param name="frame_Timestamp">The frame_Timestamp.</param>
    /// <param name="frame_Id">The frame_Id.</param>
    /// <param name="source_Id">The source_Id.</param>
    public FrameMetadata(string frame_Timestamp, int frame_Id, int? source_Id)
    {
        this.Frame_Timestamp = frame_Timestamp;
        this.Frame_Id = frame_Id;
        this.Source_Id = source_Id;
    }
}