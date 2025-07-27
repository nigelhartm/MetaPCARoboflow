using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the ValidationError schema.
/// </summary>
public class ValidationError
{
    /// <summary>
    /// Gets or sets the loc.
    /// </summary>
    [JsonProperty("loc")] 
    public List<int?> Loc { get; set; }

    /// <summary>
    /// Gets or sets the msg.
    /// </summary>
    [JsonProperty("msg")] 
    public string Msg { get; set; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ValidationError"/>.
    /// </summary>
    /// <param name="loc">The loc.</param>
    /// <param name="msg">The msg.</param>
    /// <param name="type">The type.</param>
    public ValidationError(List<int?> loc, string msg, string type)
    {
        this.Loc = loc;
        this.Msg = msg;
        this.Type = type;
    }
}