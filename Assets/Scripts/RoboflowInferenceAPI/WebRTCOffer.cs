using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WebRTCOffer schema.
/// </summary>
public class WebRTCOffer
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the sdp.
    /// </summary>
    [JsonProperty("sdp")] 
    public string Sdp { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WebRTCOffer"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="sdp">The sdp.</param>
    public WebRTCOffer(string type, string sdp)
    {
        this.Type = type;
        this.Sdp = sdp;
    }
}