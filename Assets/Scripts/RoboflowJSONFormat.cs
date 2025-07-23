using System;
using System.Collections.Generic;

[Serializable]
public class RoboflowImageSize
{
    public int? width;
    public int? height;
}

[Serializable]
public class RoboflowPrediction
{
    public float x;
    public float y;
    public float width;
    public float height;
    public float confidence;
    public string @class;
    public int class_id;
    public string detection_id;
}

[Serializable]
public class RoboflowResponseRoot
{
    public string inference_id;
    public float time;
    public RoboflowImageSize image;
    public List<RoboflowPrediction> predictions;
}