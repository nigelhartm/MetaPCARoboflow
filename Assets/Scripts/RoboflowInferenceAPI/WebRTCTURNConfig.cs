using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WebRTCTURNConfig schema.
/// </summary>
public class WebRTCTURNConfig
{
    /// <summary>
    /// Gets or sets the urls.
    /// </summary>
    [JsonProperty("urls")] 
    public string Urls { get; set; }

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [JsonProperty("username")] 
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the credential.
    /// </summary>
    [JsonProperty("credential")] 
    public string Credential { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WebRTCTURNConfig"/>.
    /// </summary>
    /// <param name="urls">The urls.</param>
    /// <param name="username">The username.</param>
    /// <param name="credential">The credential.</param>
    public WebRTCTURNConfig(string urls, string username, string credential)
    {
        this.Urls = urls;
        this.Username = username;
        this.Credential = credential;
    }
}