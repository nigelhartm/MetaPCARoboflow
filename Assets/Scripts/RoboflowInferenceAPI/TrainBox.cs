using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the TrainBox schema.
/// </summary>
public class TrainBox
{
    /// <summary>
    /// Center x coordinate in pixels of train box
    /// </summary>
    [JsonProperty("x")] 
    public int X { get; set; }

    /// <summary>
    /// Center y coordinate in pixels of train box
    /// </summary>
    [JsonProperty("y")] 
    public int Y { get; set; }

    /// <summary>
    /// Width in pixels of train box
    /// </summary>
    [JsonProperty("w")] 
    public int W { get; set; }

    /// <summary>
    /// Height in pixels of train box
    /// </summary>
    [JsonProperty("h")] 
    public int H { get; set; }

    /// <summary>
    /// Class name of object this box encloses
    /// </summary>
    [JsonProperty("cls")] 
    public string Cls { get; set; }

    /// <summary>
    /// Whether this object is a positive or negative example for this class
    /// </summary>
    [JsonProperty("negative")] 
    public bool Negative { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="TrainBox"/>.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="w">The w.</param>
    /// <param name="h">The h.</param>
    /// <param name="cls">The cls.</param>
    public TrainBox(int x, int y, int w, int h, string cls)
    {
        this.X = x;
        this.Y = y;
        this.W = w;
        this.H = h;
        this.Cls = cls;
    }
}