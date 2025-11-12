# MetaPCA-Roboflow

A Unity plugin that brings you custom-trained object detection to XR, powered by Roboflow and optimized for Meta Quest.

<img src="https://github.com/user-attachments/assets/ef565f29-b837-4c57-8328-1973be15b9a4" alt="MetaPCARoboflow" width="540px">

## 🔎 Overview
* Roboflow is a platform for building, training, and deploying computer vision models, with milions of users.
* This project runs real-time, custom-trained computer vision model on Meta Quest via [Roboflow Inference Server](https://github.com/roboflow/inference), using Meta's Camera Access (PCA).

### Supported Inference Types:
- ✅ Object Detection
- ✅ Classification
- ✅ Instance Segmentation
- ✅ Keypoint Detection

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
For CUDA I recommend this link https://developer.nvidia.com/cuda-downloads

### 3A. Run Unity sample

* Open `RoboflowUnityTutorial.unity` in Unity.
* Create your APIKeys.cs file (see below).
* Play the scene. The first inference call may take a few seconds while the model is cached.

### 3B. Run Meta Quest sample

Change the IP address in the `RoboflowCaller.cs` at `client = new RoboflowInferenceClient(APIKeys.RF_API_KEY, "http://192.168.0.220:9001");` to the one of your inference server (e.g. your computer).
Then create an android build of the `MetaQuestSample.unity` Scene and run it on the Meta Quest.


* Open MetaQuestSample.unity.

* Set the correct IP address in `RoboflowCaller.cs` or directly in the scenes GameObject:

```csharp
client = new RoboflowInferenceClient(APIKeys.RF_API_KEY, "http://YOUR_COMPUTER_IP:9001");
```

* Build the project for Android (XR Plugin Management > Oculus).
* Deploy and run on Meta Quest with permissions for camera and local network access.

> :warning: **Server not running**: Don't forget that the server need to be started before and the first call takes up to a minute to download the model before!

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

## 🚀 Use your own model
To run your own model with the Meta Quest sample take care of these steps

* Open the MetaQuestSample Scene
* Open the RoboflowCaller in the Inspector
* Set RF_MODEL = "...";
* Set LOCAL_SERVER_IP_ADDRESS = Your Local IP Address

---

## 🚀 Hosted (Serverless) API

You can now use Roboflow's hosted (serverless) endpoint instead of running a local inference server. This makes it much faster to get started — no local server to install or maintain. The hosted endpoint is at `https://serverless.roboflow.com/{model_path}?api_key=YOUR_KEY` and accepts the image as plain base64 text in the POST body.

Key points:
- **Faster setup**: no local inference server required.
- **API key required**: requests must include your Roboflow API key (appended as `?api_key=...`).
- **Model selection via URL**: the model path (e.g. `xraihack_bears-fndxs/6`) is part of the request URL.
- **HostedModelType**: because the hosted endpoint does not accept an explicit model-type parameter, the client requires you to declare the model type up-front. This library exposes a `HostedModelType` enum — set the correct type when constructing `RoboflowInferenceClient` so the client knows how to parse responses.

Example (Object Detection - hosted):

```csharp
// Create a hosted client for object detection
var client = new RoboflowInferenceClient(
    APIKeys.RF_API_KEY,
    "https://serverless.roboflow.com",
    RoboflowInferenceClient.ApiMode.Hosted,
    RoboflowInferenceClient.HostedModelType.ObjectDetection
);

// RF_MODEL must be the hosted model path
string RF_MODEL = "xraihack_bears-fndxs/6";

// image: an InferenceRequestImage whose Value contains base64 image bytes
var request = new ObjectDetectionInferenceRequest(RF_MODEL, image);

StartCoroutine(client.InferObjectDetection(request,
    response => {
        Debug.Log("Detections: " + response.Predictions.Count);
    },
    error => {
        Debug.LogError("Hosted inference error: " + error);
    }
));
```

Notes and caveats:
- The hosted endpoint expects the POST body to be plain base64 text (not JSON). This client will send the `request.Image.Value` string as the body when in hosted mode.
- When constructing `RoboflowInferenceClient` in hosted mode you must pass the appropriate `HostedModelType` (for example `HostedModelType.InstanceSegmentation` if the model is a segmentation model). The client validates this and returns an error if you call a mismatched inference method.
- Hosted is ideal for quick testing and demos; for high-throughput or private models you may still prefer a local inference server.

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

## Relevant Sources & Opportunities

* [SensAI Kits GitHub](https://github.com/XRBootcamp/SensAIKits) - Main hub for all XR AI kits
* [SensAI Hackademy](https://www.sensaihackademy.com) - Early access program for courses and toolkits
* [SensAI Hack](https://sensaihack.com) - Upcoming hackathons where you can use the kits

---

## Resources & Credits

* [Roboflow](https://roboflow.com) for their open Inference API
* <a href="https://github.com/xrdevrob/QuestCameraKit" title="">PCA Samples by Rob</a><br>
* <a href="https://github.com/oculus-samples/Unity-PassthroughCameraApiSamples/" title="">Meta for Passthrough Camera API</a><br>

---

## 📄 License
MIT – Free to use, modify and learn from.
