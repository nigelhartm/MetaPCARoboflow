# MetaPCARoboflow

This Unity project demonstrates how to perform real-time AI inference using the [Roboflow Inference Server](https://github.com/roboflow/inference), powered by a full C# Roboflow API wrapper.

# Supports:
- ✅ Object Detection
- ✅ Classification
- ✅ Instance Segmentation
- ✅ Keypoint Detection

# Unity Integration



https://github.com/user-attachments/assets/c3eed80b-bb17-44ce-ae04-5664c7e76728



# Meta Quest Integration (realtime inference with **PCA**)



https://github.com/user-attachments/assets/e8b7b40e-c85a-4ed8-aea8-e7c395433576



---

## 🚀 Getting Started

### 1. Clone this Repository
```bash
git clone https://github.com/nigelhartm/MetaPCARoboflow.git
````

### 2. Setup Roboflow Inference Server (required)

You **must run a local inference server** from Roboflow. Follow their official setup:

👉 [https://github.com/roboflow/inference](https://github.com/roboflow/inference)

### 3A. Run Unity sample

Open the `RoboflowUnityTutorial.unity` Scene and start it. The first call always take a bit longer, because the models need to get buffered locally first.

### 3B. Run Meta Quest sample

Change the IP address in the `RoboflowCaller.cs` at `client = new RoboflowInferenceClient(APIKeys.RF_API_KEY, "http://192.168.0.220:9001");` to the one of your inference server (e.g. your computer).
Then create an android build of the `MetaQuestSample.unity` Scene and run it on the Meta Quest.

## 🧠 Roboflow API Wrapper (C#)

This repo contains a fully functional Roboflow API client written in C#.
It supports simple, type-safe calls to any inference type.

### ✅ Usage Example (Object Detection)

```csharp
var client = new RoboflowInferenceClient("YOUR_API_KEY", "http://localhost:9001");

var image = new InferenceRequestImage("base64", Convert.ToBase64String(myTexture.EncodeToPNG()));

var request = new ObjectDetectionInferenceRequest("my-model-id/1", image);

StartCoroutine(client.InferObjectDetection(request, 
    response => {
        Debug.Log("Success: " + response.Predictions.Count + " detections");
    },
    error => {
        Debug.LogError("Error: " + error);
    }));
```

You can also call:

* `InferClassification(...)`
* `InferInstanceSegmentation(...)`
* `InferKeypointsDetection(...)`

And the Request/Responses accordingly!

---

## 👓 Meta Quest Passthrough Integration

Using the **Meta XR SDK** and Unity Passthrough Camera API, this project supports **real-time live camera inference** in XR.

### Features:
* Live webcam (WebCamTexture) converted to base64 image
* Auto detection and marker overlay
* Confidence filtering and label visualization
* Uses Meta’s `PassthroughCameraUtils.ScreenPointToRayInWorld` for correct ray placement
* Interactive marker tracking + relationship logic

---

## 🔑 Setup Notes

* Create a file Assets/Secrets/`APIKeys.cs` with your API key:

```csharp
public static class APIKeys
{
    public const string RF_API_KEY = "your-roboflow-api-key";
}
```

* In XR mode, make sure your Quest has permission to access local network via (HTTP) and the inference server is reachable.

---

## ❤️ Credits

* [Roboflow](https://roboflow.com) for their open Inference API
* Meta for Passthrough Camera API

## Resources

<a href="https://www.flaticon.com/free-icons/heart" title="heart icons">Heart icons created by Vlad Szirka - Flaticon</a><br>
<a href="https://www.flaticon.com/free-icons/bear" title="bear icons">Bear icons created by Andri Graphic - Flaticon</a><br>
<a href="https://www.flaticon.com/free-icons/cry" title="cry icons">Cry icons created by Creativenoys01 - Flaticon</a><br>
<a href="https://console.cloud.google.com/marketplace/product/roboflow-public/roboflow" title="cry icons">Roboflow Icon</a><br>
---

## 📄 License
MIT – Free to use, modify and learn from.
