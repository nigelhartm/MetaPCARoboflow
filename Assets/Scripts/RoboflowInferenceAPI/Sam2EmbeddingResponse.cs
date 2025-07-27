using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// SAM embedding response.
/// 
/// Attributes:
///     embeddings (Union[List[List[List[List[float]]]], Any]): The SAM embedding.
///     time (float): The time in seconds it took to produce the embeddings including preprocessing.
/// </summary>
public class Sam2EmbeddingResponse
{
    /// <summary>
    /// Image id embeddings are cached to
    /// </summary>
    [JsonProperty("image_id")] 
    public string Image_Id { get; set; }

    /// <summary>
    /// The time in seconds it took to produce the embeddings including preprocessing
    /// </summary>
    [JsonProperty("time")] 
    public float Time { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Sam2EmbeddingResponse"/>.
    /// </summary>
    /// <param name="image_Id">The image_Id.</param>
    /// <param name="time">The time.</param>
    public Sam2EmbeddingResponse(string image_Id, float time)
    {
        this.Image_Id = image_Id;
        this.Time = time;
    }
}