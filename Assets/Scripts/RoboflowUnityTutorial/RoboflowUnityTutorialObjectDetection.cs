using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

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
    [SerializeField] private OverlayManager overlayManager; // For drawing overlays on UI
    [SerializeField] private RectTransform overlayRect; // RectTransform for the overlay area

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
        overlayRect.sizeDelta = new Vector2(displayImage.texture.width, displayImage.texture.height); // Set overlay size to match image
        overlayManager.Clear(); // Clear any previous overlays
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
        Debug.Log("Raw Response: " + JsonConvert.SerializeObject(response));
        overlayManager.Clear();

        if (response?.Predictions?.Count > 0)
        {
            Texture2D tex = displayImage.texture as Texture2D;
            if (tex == null) return;

            Vector2 imageSize = new Vector2(tex.width, tex.height);

            foreach (var p in response.Predictions)
            {
                overlayManager.DrawBoundingBox(p.X, p.Y, p.Width, p.Height, $"{p.Class} ({p.Confidence:F2})", imageSize);
            }
        }
        else
        {
            overlayManager.Clear();
        }
    }

    // Handler for Classification response
    private void OnResponse(ClassificationInferenceResponse response)
    {
        Debug.Log("Raw Response: " + JsonConvert.SerializeObject(response));
        overlayManager.Clear(); // Clear previous overlays

        if (response?.Predictions?.Count > 0)
        {
            // Get the top prediction (most confident one)
            var bestPrediction = response.Predictions[0];
            string label = $"{bestPrediction.Class} ({bestPrediction.Confidence:F2})";

            // Draw the classification label at the top of the image
            overlayManager.DrawClassificationLabel(label);

            Debug.Log($"Classification: {label}");
        }
        else
        {
            Debug.Log("No classification predictions");
        }
    }


    private void OnResponse(InstanceSegmentationInferenceResponse response)
    {
        Debug.Log("Raw Response: " + JsonConvert.SerializeObject(response));
        overlayManager.Clear(); // Clear previous overlays

        if (response?.Predictions?.Count > 0)
        {
            Texture2D tex = displayImage.texture as Texture2D;
            if (tex == null) return;

            Vector2 imageSize = new Vector2(tex.width, tex.height);

            foreach (var p in response.Predictions)
            {
                // Convert list of PointOutput to Vector2 list
                List<Vector2> polygonPoints = new();
                foreach (var pt in p.Points)
                {
                    polygonPoints.Add(new Vector2(pt.X, pt.Y));
                }

                // Draw the polygon in UI space
                overlayManager.DrawPolygon(polygonPoints, imageSize);

                // Optional: Draw label text near the top-left of the polygon
                //overlayManager.DrawClassificationLabel($"{p.Class} ({p.Confidence:F2})");

                Debug.Log($"Drew instance polygon for {p.Class} with {polygonPoints.Count} points");
            }
        }
        else
        {
            Debug.Log("No instance segmentation predictions found.");
        }
    }


    // Handler for Keypoints Detection response
    private void OnResponse(KeypointsDetectionInferenceResponse response)
    {
        Debug.Log("keypoints started");
        if (response?.Predictions == null || response.Predictions.Count == 0)
        {
            Debug.Log("No predictions found.");
            return;
        }

        Texture2D tex = displayImage.texture as Texture2D;
        if (tex == null) return;

        Vector2 imageSize = new Vector2(tex.width, tex.height);

        foreach (var prediction in response.Predictions)
        {
            if (prediction.Keypoints == null || prediction.Keypoints.Count == 0)
                continue;

            List<Vector2> keypointPositions = new();
            foreach (var kp in prediction.Keypoints)
                keypointPositions.Add(new Vector2(kp.X, kp.Y));

            overlayManager.DrawKeypoints(keypointPositions, imageSize);
        }
    }

    // Generic handler for API error responses
    private void OnError(string error)
    {
        Debug.LogError("Inference error: " + error);
        Debug.Log("no predictions");
    }
}
