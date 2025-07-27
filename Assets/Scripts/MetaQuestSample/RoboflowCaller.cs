using PassthroughCameraSamples;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using Meta.XR;

/// <summary>
/// Handles webcam streaming, sending frames to Roboflow,
/// receiving detections, and rendering tracked objects in 3D space.
/// </summary>
public class RoboflowCaller : MonoBehaviour
{
    [Header("Camera & Streaming")]
    [SerializeField] private RawImage imageDisplay;                  // UI display for webcam feed
    [SerializeField] private WebCamTextureManager webCamTextureManager;
    private Texture2D texture2D = null;                              // Used for sending frames to Roboflow
    private bool isStreaming = false;                                // Streaming toggle

    [Header("3D Scene References")]
    [SerializeField] private EnvironmentRaycastManager envRaycastManager;
    private Camera _mainCamera;
    [SerializeField] private GameObject GUI;
    [SerializeField] private GameObject leftHandController;
    [SerializeField] private GameObject CenterEyeAnchor;

    [Header("Tracked Marker Objects")]
    [SerializeField] private RoboflowObject[] _markerPrefabs; // Prefabs to instantiate
    private Dictionary<int, RoboflowObject> _activeMarkerMap = new(); // runtime pool
    private float minConfidence = 0.84f;                             // Detection confidence threshold
    [SerializeField] private RoboflowObject pandaMarker; // Panda marker prefab
    [SerializeField] private RoboflowObject bearMarker;  // Bear marker prefab

    [Header("Debug Elements")]
    [SerializeField] private GameObject debugTextPanda;
    [SerializeField] private GameObject debugTextBear;
    [SerializeField] private MeshRenderer pandaRenderer;
    [SerializeField] private MeshRenderer bearRenderer;
    [SerializeField] private bool DEBUG_MODE = true;

    private RoboflowInferenceClient client;                          // API client

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    /// <summary>
    /// Toggle debug UI and object visuals.
    /// </summary>
    public void onDebugClicked()
    {
        DEBUG_MODE = !DEBUG_MODE;
        debugTextPanda.SetActive(DEBUG_MODE);
        debugTextBear.SetActive(DEBUG_MODE);
        pandaRenderer.enabled = DEBUG_MODE;
        bearRenderer.enabled = DEBUG_MODE;
    }

    private void Start()
    {
        // Initialize Roboflow client with local server URL
        client = new RoboflowInferenceClient(APIKeys.RF_API_KEY, "http://192.168.0.220:9001");

        // Build marker pool dynamically
        /*foreach (var prefab in _markerPrefabs)
        {
            var instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            instance.Init();
            instance.Disable();
            _activeMarkerMap[prefab.ClassID] = instance;
        }*/
        _activeMarkerMap[pandaMarker.ClassID] = pandaMarker;
        _activeMarkerMap[bearMarker.ClassID] = bearMarker;
        pandaMarker.Init();
        bearMarker.Init();


        StartCoroutine(updateTexture2D());   // Start webcam-to-texture updates
    }

    private void Update()
    {
        // Open/close GUI using controller button
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (!GUI.activeSelf)
            {
                GUI.transform.position = CenterEyeAnchor.transform.position + CenterEyeAnchor.transform.forward * 0.6f;
                GUI.transform.rotation = Quaternion.LookRotation(GUI.transform.position - CenterEyeAnchor.transform.position);
                GUI.SetActive(true);
            }
            else
            {
                GUI.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Starts/stops the streaming coroutine.
    /// </summary>
    public void onStreamingButtonCLicked()
    {
        if (isStreaming)
        {
            isStreaming = false;
            clearPreviousMarkers();
            Debug.Log("Streaming stopped.");
        }
        else
        {
            GUI.SetActive(false);
            isStreaming = true;
            StartCoroutine(callRoboflow());
            Debug.Log("Streaming started.");
        }
    }

    /// <summary>
    /// Continuously updates a Texture2D with the webcam feed.
    /// </summary>
    private IEnumerator updateTexture2D()
    {
        while (webCamTextureManager.WebCamTexture == null)
            yield return null;

        initialImageDisplay(); // show webcam feed in UI

        // Create Texture2D to hold captured frames
        texture2D = new Texture2D(webCamTextureManager.WebCamTexture.width, webCamTextureManager.WebCamTexture.height, TextureFormat.RGB24, false);

        while (true)
        {
            texture2D.SetPixels(webCamTextureManager.WebCamTexture.GetPixels());
            texture2D.Apply();
            yield return new WaitForSeconds(0.1f); // ~10 FPS roboflow can not handle more than that in my case
        }
    }

    /// <summary>
    /// Sets the image display to show the webcam feed.
    /// </summary>
    private void initialImageDisplay()
    {
        if (imageDisplay != null && webCamTextureManager.WebCamTexture != null)
        {
            imageDisplay.texture = webCamTextureManager.WebCamTexture;
        }
    }

    /// <summary>
    /// Scales down a texture to the given dimensions.
    /// </summary>
    private Texture2D resizeTexture(Texture2D source, int targetWidth, int targetHeight)
    {
        var rt = RenderTexture.GetTemporary(targetWidth, targetHeight);
        rt.filterMode = FilterMode.Bilinear;
        var previous = RenderTexture.active;
        RenderTexture.active = rt;
        Graphics.Blit(source, rt);

        var result = new Texture2D(targetWidth, targetHeight, TextureFormat.RGBA32, false);
        result.ReadPixels(new Rect(0, 0, targetWidth, targetHeight), 0, 0);
        result.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(rt);
        return result;
    }

    /// <summary>
    /// Sends frames to Roboflow, waits for a response, and visualizes detections.
    /// </summary>
    private IEnumerator callRoboflow()
    {
        while (isStreaming)
        {
            if (texture2D == null)
            {
                yield return null;
                continue;
            }

            // Convert to base64 for API
            byte[] png = resizeTexture(texture2D, 512, 512).EncodeToPNG();
            yield return null;
            string base64Image = Convert.ToBase64String(png);
            yield return null;
            var image = new InferenceRequestImage("base64", base64Image);

            bool isDone = false;

            // Call Roboflow and wait for completion
            yield return StartCoroutine(client.InferObjectDetection(
                new ObjectDetectionInferenceRequest("xraihack_bears-fndxs/2", image),
                response => { OnResponse(response); isDone = true; },
                error => { Debug.Log(error); isDone = true; }
            ));
            yield return new WaitUntil(() => isDone);
        }
    }

    /// <summary>
    /// Callback for successful inference response.
    /// </summary>
    private void OnResponse(ObjectDetectionInferenceResponse response)
    {
        if (response.Predictions != null && response.Predictions.Count > 0)
        {
            foreach (var pred in response.Predictions)
                Debug.Log($"Detected {pred.Class} at ({pred.X},{pred.Y}) confidence: {pred.Confidence}");

            renderDetections(response.Predictions);
        }
        else
        {
            Debug.Log("No predictions found.");
        }
    }

    private void clearPreviousMarkers()
    {
        foreach (var marker in _activeMarkerMap.Values)
        {
            if (marker == null) continue;
            marker.Disable();
        }
    }

    /// <summary>
    /// Returns an existing marker for a given class ID.
    /// </summary>
    private RoboflowObject checkForExistingMarker(int classID)
    {
        _activeMarkerMap.TryGetValue(classID, out var marker);
        return marker;
    }


    /// <summary>
    /// Projects 2D detections into 3D space using raycasting and renders marker objects. Copy from Rob's PCA samples.
    /// </summary>
    public void renderDetections(List<ObjectDetectionPrediction> predictions)
    {
        var intrinsics = PassthroughCameraUtils.GetCameraIntrinsics(webCamTextureManager.Eye);
        var camRes = intrinsics.Resolution;
        var imageWidth = 512;
        var imageHeight = 512;
        var halfWidth = imageWidth * 0.5f;
        var halfHeight = imageHeight * 0.5f;

        for (int i = 0; i < predictions.Count; i++)
        {
            var prediction = predictions[i];

            if (prediction.Confidence < minConfidence)
            {
                Debug.Log($"Detection {i} below threshold.");
                continue;
            }

            RoboflowObject marker = checkForExistingMarker(prediction.Class_Id);
            if (marker == null)
            {
                Debug.Log($"No marker assigned for class {prediction.Class_Id}");
                continue;
            }

            // Convert center to pixel space
            var adjustedCenterX = prediction.X - halfWidth;
            var adjustedCenterY = prediction.Y - halfHeight;

            var perX = (adjustedCenterX + halfWidth) / imageWidth;
            var perY = (adjustedCenterY + halfHeight) / imageHeight;

            var centerPixel = new Vector2(perX * camRes.x, (1.0f - perY) * camRes.y);
            var centerRay = PassthroughCameraUtils.ScreenPointToRayInWorld(webCamTextureManager.Eye, new Vector2Int(Mathf.RoundToInt(centerPixel.x), Mathf.RoundToInt(centerPixel.y)));

            if (!envRaycastManager.Raycast(centerRay, out var centerHit))
            {
                Debug.LogWarning("Raycast failed.");
                continue;
            }

            var markerWorldPos = centerHit.point;

            // Get corners for scale estimation
            var u1 = (prediction.X - prediction.Width * 0.5f) / imageWidth;
            var v1 = (prediction.Y - prediction.Height * 0.5f) / imageHeight;
            var u2 = (prediction.X + prediction.Width * 0.5f) / imageWidth;
            var v2 = (prediction.Y + prediction.Height * 0.5f) / imageHeight;

            var tlPixel = new Vector2Int(Mathf.RoundToInt(u1 * camRes.x), Mathf.RoundToInt((1.0f - v1) * camRes.y));
            var brPixel = new Vector2Int(Mathf.RoundToInt(u2 * camRes.x), Mathf.RoundToInt((1.0f - v2) * camRes.y));

            var tlRay = PassthroughCameraUtils.ScreenPointToRayInWorld(webCamTextureManager.Eye, tlPixel);
            var brRay = PassthroughCameraUtils.ScreenPointToRayInWorld(webCamTextureManager.Eye, brPixel);

            var depth = Vector3.Distance(_mainCamera.transform.position, markerWorldPos);
            var worldTL = tlRay.GetPoint(depth);
            var worldBR = brRay.GetPoint(depth);

            var markerWidth = Mathf.Abs(worldBR.x - worldTL.x);
            var markerHeight = Mathf.Abs(worldBR.y - worldTL.y);
            var markerScale = new Vector3(markerWidth, markerHeight, 1f);

            marker.SuccesfullyTracked(markerWorldPos, CenterEyeAnchor.transform.position);
            marker.SetDebugText(prediction.Class + " " + prediction.Confidence.ToString("F2"));

            Debug.Log($"Placed marker {i} at {markerWorldPos} with scale {markerScale}");
        }
    }
}