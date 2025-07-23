using PassthroughCameraSamples;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.Networking;
using System.Collections;
using System;
using System.Collections.Generic;
using Meta.XR;

public class RoboflowCaller : MonoBehaviour
{
    // Initialize the required components
    [SerializeField] private RawImage imageDisplay;
    [SerializeField] private WebCamTextureManager webCamTextureManager;

    // Texture2D to hold the converted WebCamTexture
    private Texture2D texture2D = null;

    // Roboflow Calling
    private String ROBOFLOW_API_KEY = APIKeys.RF_API_KEY;

    private bool isStreaming = false;

    [Header("Marker Settings")]
    [SerializeField] private EnvironmentRaycastManager envRaycastManager;
    private Camera _mainCamera;

    [SerializeField] private RF_Object[] _activeMarkers; // Array to hold active markers
    private float minConfidence = 0.84f; // Minimum confidence threshold for detections

    [SerializeField] private GameObject GUI;
    [SerializeField] private GameObject leftHandController;
    [SerializeField] private GameObject CenterEyeAnchor;

    [SerializeField] private GameObject debugTextPanda;
    [SerializeField] private GameObject debugTextBear;
    [SerializeField] private MeshRenderer pandaRenderer;
    [SerializeField] private MeshRenderer bearRenderer;
    [SerializeField] private bool DEBUG_MODE = true;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void onDebugClicked()
    {
        if (!this.DEBUG_MODE)
        {
            debugTextPanda.SetActive(true);
            debugTextBear.SetActive(true);
            pandaRenderer.enabled = true;
            bearRenderer.enabled = true;
            this.DEBUG_MODE = true;
        }
        else
        {
            debugTextPanda.SetActive(false);
            debugTextBear.SetActive(false);
            pandaRenderer.enabled = false;
            bearRenderer.enabled = false;
            this.DEBUG_MODE = false;
        }
    }

        void Start()
    {
        if (ROBOFLOW_API_KEY == null || ROBOFLOW_API_KEY == "")
        {
            Debug.LogError("ROBOFLOW_API_KEY is not set. Please provide a valid API key.");
            Destroy(this);
        }

        if (_activeMarkers == null || _activeMarkers.Length == 0)
        {
            Debug.LogError("Active markers array is not initialized or empty. Please assign the markers in the inspector.");
            Destroy(this);
        }
        initMarkers();

        StartCoroutine(updateTexture2D());
    }

    private void Update()
    {
        // Was there a call for menu on left hand?
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (!GUI.activeSelf)
            {
                GUI.transform.position = CenterEyeAnchor.transform.forward * 0.6f + CenterEyeAnchor.transform.position;
                GUI.transform.rotation = Quaternion.LookRotation(GUI.transform.position - CenterEyeAnchor.transform.position);
                GUI.SetActive(true);
            }
            else
            {
                GUI.SetActive(false);
            }
        }
    }

    public void onStreamingButtonCLicked() {
        if (isStreaming)
        {
            isStreaming = false;
            clearPreviousMarkers();
            Debug.Log("Streaming stopped.");
        }
        else
        {
            GUI.SetActive(false); // Hide GUI when streaming starts
            isStreaming = true;
            StartCoroutine(callRoboflow());
            Debug.Log("Streaming started.");
        }
    }

    private IEnumerator updateTexture2D()
    {
        while(webCamTextureManager.WebCamTexture == null)
        {
            yield return null; // Wait until the WebCamTexture is initialized
        }
        initialImageDisplay();

        if (texture2D == null ||
            texture2D.width != webCamTextureManager.WebCamTexture.width ||
            texture2D.height != webCamTextureManager.WebCamTexture.height)
        {
            texture2D = new Texture2D(webCamTextureManager.WebCamTexture.width, webCamTextureManager.WebCamTexture.height, TextureFormat.RGB24, false);
        }

        // Change to limited later
        while (true)
        {
            texture2D.SetPixels(webCamTextureManager.WebCamTexture.GetPixels());
            texture2D.Apply();
            //updateImageDisplay();
            yield return new WaitForSeconds(0.1f); // Update every 100ms (10 FPS)
        }
    }

    // update display by texture2D every time
    private void updateImageDisplay()
    {
        if (imageDisplay != null && texture2D != null)
        {
            // Display the Texture2D in the RawImage
            imageDisplay.texture = texture2D;
            imageDisplay.material.mainTexture = texture2D;
        }
    }

    // sets texture to webcam tetxture
    private void initialImageDisplay()
    {
        if (imageDisplay != null && webCamTextureManager.WebCamTexture != null)
        {
            imageDisplay.texture = webCamTextureManager.WebCamTexture;
        }
    }

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

    private IEnumerator callRoboflow()
    {
        while (isStreaming)
        {
            if (texture2D == null)
            {
                yield return null;
                continue;
            }

            Debug.Log("Encoding Texture2D to PNG and converting to Base64...");
            byte[] png = resizeTexture(texture2D, 512,512).EncodeToPNG();
            yield return null; // return to the main thread to avoid blocking
            string base64Image = Convert.ToBase64String(png);
            yield return null; // return to the main thread to avoid blocking
            string jsonPayload = JsonConvert.SerializeObject(new
            {
                api_key = ROBOFLOW_API_KEY,
                model_id = "xraihack_bears-fndxs/2",
                image = new { type = "base64", value = base64Image }
            });
            using (UnityWebRequest request = new UnityWebRequest("http://192.168.0.220:9001/infer/object_detection", "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    string json = request.downloadHandler.text;
                    Debug.Log("Roboflow Response: " + json);

                    try
                    {
                        RoboflowResponseRoot root = JsonConvert.DeserializeObject<RoboflowResponseRoot>(json);

                        if (root.predictions != null && root.predictions.Count > 0)
                        {
                            foreach (var pred in root.predictions)
                            {
                                Debug.Log($"Detected {pred.@class} at ({pred.x}, {pred.y}) size ({pred.width}x{pred.height}) confidence: {pred.confidence}");
                            }
                            Debug.Log("Before calling render");
                            renderDetections(root.predictions);
                        }
                        else
                        {
                            Debug.Log("No predictions found.");
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Failed to parse Roboflow response: " + e.Message);
                    }
                }
                else
                {
                    Debug.LogError("Roboflow Error: " + request.error);
                }

                // Adjust rate of requests
                yield return new WaitForSeconds(0.1f);  // 5 FPS
            }
        }
    }

    private void initMarkers()
    {
        foreach (var marker in _activeMarkers)
        {
            marker.Init();
        }
    }

    private void clearPreviousMarkers()
    {
        foreach (var marker in _activeMarkers)
        {
           if(marker == null) continue; // Skip if marker is null
            marker.Disable();
        }
    }

    private RF_Object checkForExistingMarker(int classID) {
        foreach (var marker in _activeMarkers)
        {
            if(marker.ClassID == classID)
            {
                return marker;
            }
        }
        return null;
    }

    public void renderDetections(List<RoboflowPrediction> predictions)
    {
        var intrinsics = PassthroughCameraUtils.GetCameraIntrinsics(webCamTextureManager.Eye);
        var camRes = intrinsics.Resolution;
        var imageWidth = 512;
        var imageHeight = 512;
        var halfWidth = imageWidth * 0.5f;
        var halfHeight = imageHeight * 0.5f;

        for (var i = 0; i < predictions.Count; i++)
        {
            if(predictions[i].confidence < minConfidence)
            {
                Debug.Log($"[Detection3DRenderer] Detection {i} confidence {predictions[i].confidence} is below the threshold of {minConfidence}. Skipping.");
                continue; // Skip detections below the confidence threshold
            }
            RF_Object marker = checkForExistingMarker(predictions[i].class_id);
            if (marker == null)
            {
                Debug.Log($"[Detection3DRenderer] Detection class {predictions[i].class_id} has no associated RF_Object.");
                continue; // Skip
            }

            var detectedCenterX = predictions[i].x;
            var detectedCenterY = predictions[i].y;
            var detectedWidth = predictions[i].width;
            var detectedHeight = predictions[i].height;

            var adjustedCenterX = detectedCenterX - halfWidth;
            var adjustedCenterY = detectedCenterY - halfHeight;

            var perX = (adjustedCenterX + halfWidth) / imageWidth;
            var perY = (adjustedCenterY + halfHeight) / imageHeight;

            var centerPixel = new Vector2(perX * camRes.x, (1.0f - perY) * camRes.y);
            print($"[Detection3DRenderer] Detection {i} Center Pixel: {centerPixel}");

            var centerRay = PassthroughCameraUtils.ScreenPointToRayInWorld(webCamTextureManager.Eye, new Vector2Int(Mathf.RoundToInt(centerPixel.x), Mathf.RoundToInt(centerPixel.y)));

            if (!envRaycastManager.Raycast(centerRay, out var centerHit))
            {
                Debug.LogWarning($"[Detection3DRenderer] Detection {i}: Environment raycast failed.");
                continue;
            }

            var markerWorldPos = centerHit.point;

            var u1 = (detectedCenterX - detectedWidth * 0.5f) / imageWidth;
            var v1 = (detectedCenterY - detectedHeight * 0.5f) / imageHeight;
            var u2 = (detectedCenterX + detectedWidth * 0.5f) / imageWidth;
            var v2 = (detectedCenterY + detectedHeight * 0.5f) / imageHeight;

            var tlPixel = new Vector2Int(
                Mathf.RoundToInt(u1 * camRes.x),
                Mathf.RoundToInt((1.0f - v1) * camRes.y)
            );

            var brPixel = new Vector2Int(
                Mathf.RoundToInt(u2 * camRes.x),
                Mathf.RoundToInt((1.0f - v2) * camRes.y)
            );

            var tlRay = PassthroughCameraUtils.ScreenPointToRayInWorld(webCamTextureManager.Eye, tlPixel);
            var brRay = PassthroughCameraUtils.ScreenPointToRayInWorld(webCamTextureManager.Eye, brPixel);

            var depth = Vector3.Distance(_mainCamera.transform.position, markerWorldPos);
            var worldTL = tlRay.GetPoint(depth);
            var worldBR = brRay.GetPoint(depth);

            var markerWidth = Mathf.Abs(worldBR.x - worldTL.x);
            var markerHeight = Mathf.Abs(worldBR.y - worldTL.y);
            var markerScale = new Vector3(markerWidth, markerHeight, 1f);

            var detectedLabel = predictions[i].@class;

            var labelKey = detectedLabel.ToString();

            marker.SuccesfullyTracked(markerWorldPos, CenterEyeAnchor.transform.position);
            marker.SetDebugText(labelKey + " " + predictions[i].confidence.ToString("F2"));
            Debug.Log("Setting marker " + i + " to position: " + markerWorldPos + " with scale: " + markerScale);
        }
    }
}