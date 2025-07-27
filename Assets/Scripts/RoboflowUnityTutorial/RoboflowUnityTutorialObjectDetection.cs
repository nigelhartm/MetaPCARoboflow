using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json;

/// Supported model types that the dropdown can switch between
public enum ModelType
{
    ObjectDetection,
    Classification,
    InstanceSegmentation,
    KeypointsDetection
}

public class RoboflowUnityTutorial : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private RawImage displayImage;              // UI element to show the selected image
    [SerializeField] private TMP_Dropdown modelDropdown;         // Dropdown to select the model type
    [SerializeField] private TMP_Text debugText;                 // Text field to show inference output or errors

    [Header("Images for Inference")]
    [SerializeField] private Texture2D imageObjectDetection;     // Image for Object Detection
    [SerializeField] private Texture2D imageClassification;      // Image for Classification
    [SerializeField] private Texture2D imageInstanceSegmentation;// Image for Instance Segmentation
    [SerializeField] private Texture2D imageKeypointsDetection;  // Image for Keypoints Detection

    [Header("Roboflow Models")]
    [SerializeField] private string objectDetectionModel = "xraihack_bears-fndxs/2";
    [SerializeField] private string classificationModel = "chest-x-rays-qjmia/3";
    [SerializeField] private string instanceSegmentationModel = "road-traffic-rqbit/4";
    [SerializeField] private string keypointsDetectionModel = "human-activity-ce7zu/2";

    private RoboflowInferenceClient client;                      // Roboflow API client instance

    // Gets the currently selected model from dropdown as enum
    private ModelType currentModel => (ModelType)modelDropdown.value;

    // Unity Start method - called when the scene begins
    void Start()
    {
        client = new RoboflowInferenceClient(APIKeys.RF_API_KEY); // Initialize Roboflow API client
        UpdateDisplayImage(); // Show initial image based on selected dropdown model
    }

    // Called when dropdown value is changed by user
    public void OnModelDropdownChanged() => UpdateDisplayImage();

    // Trigger inference for the selected model type
    public void OnRunModel()
    {
        // Get selected image and model ID based on dropdown value
        Texture2D selectedImage = GetSelectedImage();
        string modelId = GetModelId();

        // Convert the image to base64-encoded PNG string
        var base64 = Convert.ToBase64String(selectedImage.EncodeToPNG());
        var image = new InferenceRequestImage("base64", base64);

        // Call correct API based on model type
        switch (currentModel)
        {
            case ModelType.ObjectDetection:
                StartCoroutine(client.InferObjectDetection(new ObjectDetectionInferenceRequest(modelId, image), OnResponse, OnError));
                break;
            case ModelType.Classification:
                StartCoroutine(client.InferClassification(new ClassificationInferenceRequest(modelId, image), OnResponse, OnError));
                break;
            case ModelType.InstanceSegmentation:
                StartCoroutine(client.InferInstanceSegmentation(new InstanceSegmentationInferenceRequest(modelId, image), OnResponse, OnError));
                break;
            case ModelType.KeypointsDetection:
                StartCoroutine(client.InferKeypointsDetection(new KeypointsDetectionInferenceRequest(modelId, image), OnResponse, OnError));
                break;
        }
    }

    // Updates the display image in the UI based on selected model
    private void UpdateDisplayImage()
    {
        displayImage.texture = GetSelectedImage();
        displayImage.SetNativeSize(); // Adjusts RawImage size to match texture dimensions
    }

    // Returns the correct test image for the selected model
    private Texture2D GetSelectedImage()
    {
        return currentModel switch
        {
            ModelType.ObjectDetection => imageObjectDetection,
            ModelType.Classification => imageClassification,
            ModelType.InstanceSegmentation => imageInstanceSegmentation,
            ModelType.KeypointsDetection => imageKeypointsDetection,
            _ => null
        };
    }

    // Returns the Roboflow model ID string based on selected model
    private string GetModelId()
    {
        return currentModel switch
        {
            ModelType.ObjectDetection => objectDetectionModel,
            ModelType.Classification => classificationModel,
            ModelType.InstanceSegmentation => instanceSegmentationModel,
            ModelType.KeypointsDetection => keypointsDetectionModel,
            _ => ""
        };
    }

    // Handler for Object Detection response
    private void OnResponse(ObjectDetectionInferenceResponse response)
    {
        Debug.Log("Raw Response: " + JsonConvert.SerializeObject(response)); // Log raw JSON

        if (response?.Predictions?.Count > 0)
        {
            string info = "";
            foreach (var p in response.Predictions)
                info += $"Found {p.Class} with confidence {p.Confidence:F2}\n";
            debugText.text = info;
        }
        else
        {
            debugText.text = "No predictions returned.";
        }
    }

    // Handler for Classification response
    private void OnResponse(ClassificationInferenceResponse response)
    {
        Debug.Log("Raw Response: " + JsonConvert.SerializeObject(response));

        if (response?.Predictions?.Count > 0)
        {
            string info = "";
            foreach (var p in response.Predictions)
                info += $"Found {p.Class} with confidence {p.Confidence:F2}\n";
            debugText.text = info;
        }
        else
        {
            debugText.text = "No predictions returned.";
        }
    }

    // Handler for Instance Segmentation response
    private void OnResponse(InstanceSegmentationInferenceResponse response)
    {
        Debug.Log("Raw Response: " + JsonConvert.SerializeObject(response));

        if (response?.Predictions?.Count > 0)
        {
            string info = "";
            foreach (var p in response.Predictions)
                info += $"Found {p.Class} with confidence {p.Confidence:F2}\n";
            debugText.text = info;
        }
        else
        {
            debugText.text = "No predictions returned.";
        }
    }

    // Handler for Keypoints Detection response
    private void OnResponse(KeypointsDetectionInferenceResponse response)
    {
        Debug.Log("Raw Response: " + JsonConvert.SerializeObject(response));

        if (response?.Predictions?.Count > 0)
        {
            string info = "";
            foreach (var p in response.Predictions)
                info += $"Found {p.Class} with confidence {p.Confidence:F2}\n";
            debugText.text = info;
        }
        else
        {
            debugText.text = "No predictions returned.";
        }
    }

    // Generic handler for API error responses
    private void OnError(string error)
    {
        Debug.LogError("Inference error: " + error);
        debugText.text = "Error: " + error;
    }
}
