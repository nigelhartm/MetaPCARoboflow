using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Image data for inference request.
/// 
/// Attributes:
///     type (str): The type of image data provided, one of 'url', 'base64', or 'numpy'.
///     value (Optional[Any]): Image data corresponding to the image type.
/// </summary>
public class InferenceRequestImage
{
    /// <summary>
    /// The type of image data provided, one of 'url', 'base64', or 'numpy'
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Image data corresponding to the image type, if type = 'url' then value is a string containing the url of an image, else if type = 'base64' then value is a string containing base64 encoded image data, else if type = 'numpy' then value is binary numpy data serialized using pickle.dumps(); array should 3 dimensions, channels last, with values in the range [0,255].
    /// </summary>
    [JsonProperty("value")] 
    public object Value { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InferenceRequestImage"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="value">Image data corresponding to the image type.</param>
    public InferenceRequestImage(string type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}