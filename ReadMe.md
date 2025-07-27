# Roboflow Unity Inference Toolkit

This Unity project demonstrates how to perform real-time AI inference using the [Roboflow Inference Server](https://github.com/roboflow/inference), powered by a full C# Roboflow API wrapper.

Supports:
- ✅ Object Detection
- ✅ Classification
- ✅ Instance Segmentation
- ✅ Keypoint Detection  
Works seamlessly in:
- 🎮 Unity Editor/Desktop
- 🕶️ Meta Quest (with **Passthrough Camera API** for live view object detection)
https://github.com/user-attachments/assets/918cf409-72e0-4ad2-930b-6b5f87c5b27d

---

## 🚀 Getting Started

### 1. Clone this Repository
```bash
git clone https://github.com/YOUR_USERNAME/roboflow-unity-inference.git
````

### 2. Setup Roboflow Inference Server (required)

You **must run a local inference server** from Roboflow. Follow their official setup:

👉 [https://github.com/roboflow/inference](https://github.com/roboflow/inference)

**Example (Docker):**

```bash
docker run --rm -it -p 9001:9001 roboflow/roboflow-inference-server-cpu:latest
```

You can now access the inference server at:

```
http://localhost:9001
```

On Meta Quest, ensure your server is reachable via local IP, e.g. `http://192.168.0.100:9001`.

---

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

## 🎮 Unity Editor Support

You can test models directly in the Unity Editor using provided example images.
Includes UI dropdown, preview image, and debug text showing predictions.

---

## 📂 Folder Structure

```
RoboflowUnity/
│
├── Scripts/
│   ├── RoboflowInferenceClient.cs      # C# Wrapper Client
│   ├── RoboflowObject.cs               # Tracked object with label & auto-disable
│   ├── RoboflowCaller.cs               # Main runtime loop for XR/Quest
│   ├── RoboflowUnityTutorial.cs       # Standalone UI tutorial for desktop/Editor
│
├── Resources/
│   └── Sample images for each model type
│
├── GeneratedSchemas/
│   └── Auto-generated C# classes from OpenAPI spec
```

---

## 🔑 Setup Notes

* Create a file called `APIKeys.cs` with your API key:

```csharp
public static class APIKeys
{
    public const string RF_API_KEY = "your-roboflow-api-key";
}
```

* In XR mode, make sure your Quest has permission to access local network and the inference server is reachable.

---

## 📸 Screenshots (Editor + Quest)

*Coming soon*

---

## ❤️ Credits

* [Roboflow](https://roboflow.com) for their open Inference API
* Meta for Passthrough Camera API
* Unity for XR platform support

---

## 📄 License
MIT – Free to use, modify and learn from.