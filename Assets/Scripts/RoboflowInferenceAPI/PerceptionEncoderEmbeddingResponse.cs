using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Response for PERCEPTION_ENCODER embedding.
/// 
/// Attributes:
///     embeddings (List[List[float]]): A list of embeddings, each embedding is a list of floats.
///     time (float): The time in seconds it took to produce the embeddings including preprocessing.
/// </summary>
public class PerceptionEncoderEmbeddingResponse
{
    /// <summary>
    /// Unique identifier of inference
    /// </summary>
    [JsonProperty("inference_id")] 
    public string Inference_Id { get; set; }

    /// <summary>
    /// The frame id of the image used in inference if the input was a video
    /// </summary>
    [JsonProperty("frame_id")] 
    public int? Frame_Id { get; set; }

    /// <summary>
    /// The time in seconds it took to produce the embeddings including preprocessing
    /// </summary>
    [JsonProperty("time")] 
    public float? Time { get; set; }

    /// <summary>
    /// A list of embeddings, each embedding is a list of floats
    /// </summary>
    [JsonProperty("embeddings")] 
    public List<List<float>> Embeddings { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="PerceptionEncoderEmbeddingResponse"/>.
    /// </summary>
    /// <param name="embeddings">The embeddings.</param>
    public PerceptionEncoderEmbeddingResponse(List<List<float>> embeddings)
    {
        this.Embeddings = embeddings;
    }
}