using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// SAM embedding response.
/// 
/// Attributes:
///     embeddings (Union[List[List[List[List[float]]]], Any]): The SAM embedding.
///     time (float): The time in seconds it took to produce the embeddings including preprocessing.
/// </summary>
public class SamEmbeddingResponse
{
    /// <summary>
    /// If request format is json, embeddings is a series of nested lists representing the SAM embedding. If request format is binary, embeddings is a binary numpy array. The dimensions of the embedding are 1 x 256 x 64 x 64.
    /// </summary>
    [JsonProperty("embeddings")] 
    public List<List<List<List<float>>>> Embeddings { get; set; }

    /// <summary>
    /// The time in seconds it took to produce the embeddings including preprocessing
    /// </summary>
    [JsonProperty("time")] 
    public float Time { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="SamEmbeddingResponse"/>.
    /// </summary>
    /// <param name="embeddings">The embeddings.</param>
    /// <param name="time">The time.</param>
    public SamEmbeddingResponse(List<List<List<List<float>>>> embeddings, float time)
    {
        this.Embeddings = embeddings;
        this.Time = time;
    }
}