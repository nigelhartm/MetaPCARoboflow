# MetaPCARoboflow

MetaPCARoboflow is a Unity-based application demonstrating real-time AI inference using the [Roboflow Inference Server](https://github.com/roboflow/inference). It is powered by a full-featured C# Roboflow API wrapper and supports seamless integration with Meta Quest's Passthrough Camera API (PCA) for mixed reality applications.

Use it to add object detection, classification, keypoint tracking, and instance segmentation to both 2D and 3D XR environments.

# Supported Inference Types:
- ✅ Object Detection
- ✅ Classification
- ✅ Instance Segmentation
- ✅ Keypoint Detection

# Unity Integration



https://github.com/user-attachments/assets/c3eed80b-bb17-44ce-ae04-5664c7e76728



# Meta Quest Integration (Live XR Inference)



https://github.com/user-attachments/assets/e8b7b40e-c85a-4ed8-aea8-e7c395433576



---

## 🚀 Getting Started

### 1. Clone this Repository
```bash
git clone https://github.com/nigelhartm/MetaPCARoboflow.git
````

### 2. Setup Roboflow Inference Server (required)

👉 [https://github.com/roboflow/inference](https://github.com/roboflow/inference)

To run AI inference, you need to start a local Roboflow Inference Server on your computer (PC or Mac).
This project does not run the model directly on the Meta Quest or on-device. Instead, it sends images from Unity or your headset to the inference server running on your desktop.

### 3A. Run Unity sample

* Open `RoboflowUnityTutorial.unity` in Unity.
* Create your APIKeys.cs file (see below).
* Play the scene. The first inference call may take a few seconds while the model is cached.

### 3B. Run Meta Quest sample

Change the IP address in the `RoboflowCaller.cs` at `client = new RoboflowInferenceClient(APIKeys.RF_API_KEY, "http://192.168.0.220:9001");` to the one of your inference server (e.g. your computer).
Then create an android build of the `MetaQuestSample.unity` Scene and run it on the Meta Quest.

* Open MetaQuestSample.unity.

* Set the correct IP address in `RoboflowCaller.cs`:

```csharp
client = new RoboflowInferenceClient(APIKeys.RF_API_KEY, "http://YOUR_COMPUTER_IP:9001");
```

* Build the project for Android (XR Plugin Management > Oculus).
* Deploy and run on Meta Quest with permissions for camera and local network access.

---

## 🔑 Roboflow API Key Setup

* Create a file Assets/Secrets/`APIKeys.cs` with your API key:

```csharp
public static class APIKeys
{
    public const string RF_API_KEY = "your-roboflow-api-key";
}
```

---

## 🧠 Roboflow API Wrapper (C#)

This project includes a complete and strongly-typed C# wrapper around the Roboflow Inference API.

### Usage Example (Object Detection)

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

✅ Also supports:
* `InferClassification(...)`
* `InferInstanceSegmentation(...)`
* `InferKeypointsDetection(...)`

Each with corresponding request/response types.

---

## 👓 Meta Quest XR Features

Using the **Meta XR SDK** and Unity Passthrough Camera API, this project supports **real-time live camera inference** in XR.

### Features:
* Live webcam (WebCamTexture) converted to base64 image
* Auto detection and marker overlay
* Confidence filtering and label visualization
* Raycasting into real world
* Interactive marker tracking

---

## Resources & Credits

* [Roboflow](https://roboflow.com) for their open Inference API
* <a href="https://github.com/xrdevrob/QuestCameraKit" title="">PCA Samples by Rob</a><br>
* <a href="https://github.com/oculus-samples/Unity-PassthroughCameraApiSamples/" title="">Meta for Passthrough Camera API</a><br>
* <a href="https://www.flaticon.com/free-icons/heart" title="heart icons">Heart icons created by Vlad Szirka - Flaticon</a><br>
* <a href="https://www.flaticon.com/free-icons/bear" title="bear icons">Bear icons created by Andri Graphic - Flaticon</a><br>
* <a href="https://www.flaticon.com/free-icons/cry" title="cry icons">Cry icons created by Creativenoys01 - Flaticon</a><br>
* <a href="https://console.cloud.google.com/marketplace/product/roboflow-public/roboflow" title="cry icons">Roboflow Icon</a><br>

---

## 📄 License
MIT – Free to use, modify and learn from.
