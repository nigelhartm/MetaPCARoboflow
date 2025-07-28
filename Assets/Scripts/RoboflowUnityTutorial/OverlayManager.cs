using System.Collections.Generic;
using Meta.WitAi;
using TMPro;
using UnityEngine;

/// <summary>
/// OverlayManager draws prediction overlays (boxes, polygons, keypoints, labels)
/// on top of a RawImage using Unity UI components.
/// </summary>
public class OverlayManager : MonoBehaviour
{
    [Header("UI Target")]
    [SerializeField] private RectTransform imageRect;       // RectTransform of the RawImage displaying the inference
    [SerializeField] private RectTransform overlayParent;   // Parent container under the canvas (same size/position as imageRect)

    [Header("Prefabs & Materials")]
    [SerializeField] private GameObject boundingBoxPrefab;  // UI Image for bounding box
    [SerializeField] private TMP_Text textLabelPrefab;      // Text label for class names
    [SerializeField] private GameObject keypointCirclePrefab; // Small UI circle for keypoints
    [SerializeField] private Material lineRendererMaterial; // Line material for keypoint/polygon lines

    private readonly List<GameObject> _activeOverlays = new();

    /// <summary>
    /// Clears all active overlays from previous frame
    /// </summary>
    public void Clear()
    {
        foreach (var go in _activeOverlays)
            Destroy(go);
        _activeOverlays.Clear();
    }

    /// <summary>
    /// Draws a bounding box and a text label in screen UI space
    /// </summary>
    public void DrawBoundingBox(float x, float y, float width, float height, string label, Vector2 imageSize)
    {
        // Roboflow: center-based (x, y), top-left origin (0,0)
        float boxLeft = x - width / 2;
        float boxTop = y - height / 2;

        // Convert to normalized anchor coordinates (0–1)
        float normalizedX = boxLeft / imageSize.x;
        float normalizedY = 1f - (boxTop / imageSize.y); // Flip Y because UI space is bottom-left origin

        float normalizedWidth = width / imageSize.x;
        float normalizedHeight = height / imageSize.y;

        // Instantiate and configure the bounding box
        GameObject box = Instantiate(boundingBoxPrefab, overlayParent);
        RectTransform boxRect = box.GetComponent<RectTransform>();
        boxRect.anchorMin = new Vector2(normalizedX, normalizedY - normalizedHeight);
        boxRect.anchorMax = new Vector2(normalizedX + normalizedWidth, normalizedY);
        boxRect.offsetMin = boxRect.offsetMax = Vector2.zero;

        // Instantiate and place the label
        TMP_Text labelText = Instantiate(textLabelPrefab, overlayParent);
        RectTransform labelRect = labelText.GetComponent<RectTransform>();
        labelRect.anchorMin = new Vector2(normalizedX, normalizedY);
        labelRect.anchorMax = new Vector2(normalizedX, normalizedY);
        labelRect.anchoredPosition = new Vector2(4f, -4f); // small offset inside top-left of box
        labelText.text = label;
        labelText.fontSize = 50;

        _activeOverlays.Add(box);
        _activeOverlays.Add(labelText.gameObject);
    }


    /// <summary>
    /// Draws a polygon (e.g., from instance segmentation) using a LineRenderer
    /// </summary>
    public void DrawPolygon(List<Vector2> points, Vector2 imageSize)
    {
        Debug.Log($"Drawing polygon with {points.Count} points on image size {imageSize}");
        GameObject polyGO = new("PolygonLine");
        polyGO.transform.SetParent(overlayParent, false);
        var line = polyGO.AddComponent<LineRenderer>();
        line.material = lineRendererMaterial;
        line.loop = true;
        line.positionCount = points.Count;
        line.widthMultiplier = 1f;
        line.useWorldSpace = false;
        line.startWidth = 0.4f;
        line.endWidth = 0.4f;
        for (int i = 0; i < points.Count; i++)
        {
            float x = ((points[i].x / imageSize.x) * imageRect.sizeDelta.x) - imageSize.x/2;
            float y = ((1f - points[i].y / imageSize.y) * imageRect.sizeDelta.y) - imageSize.y / 2;
            line.SetPosition(i, new Vector3(x, y, 0));
        }

        _activeOverlays.Add(polyGO);
    }

    /// <summary>
    /// Draws keypoints as circles and optionally connects them with lines
    /// </summary>
    public void DrawKeypoints(List<Vector2> keypoints, Vector2 imageSize)
    {
        Debug.Log($"draw keypoints number {keypoints.Count}");

        foreach (var point in keypoints)
        {
            Vector2 normalized = new Vector2(point.x / imageSize.x, point.y / imageSize.y);
            Vector2 anchoredPos = new Vector2(
                normalized.x * imageRect.sizeDelta.x,
                (1 - normalized.y) * imageRect.sizeDelta.y // Flip Y
            );

            GameObject dot = Instantiate(keypointCirclePrefab, overlayParent);
            RectTransform dotRect = dot.GetComponent<RectTransform>();
            dotRect.anchorMin = new Vector2(0, 0);
            dotRect.anchorMax = new Vector2(0, 0);
            dotRect.anchoredPosition = anchoredPos;

            _activeOverlays.Add(dot);
        }
    }


    /// <summary>
    /// Draws a classification label above the image
    /// </summary>
    public void DrawClassificationLabel(string label)
    {
        TMP_Text text = Instantiate(textLabelPrefab, overlayParent);
        text.text = label;
        text.rectTransform.anchorMin = text.rectTransform.anchorMax = new Vector2(0.5f, 1f); // top center
        text.rectTransform.anchoredPosition = new Vector2(0, -75f); // offset down
        text.fontSize = 60;
        text.color = Color.magenta; // Optional: set color for visibility

        _activeOverlays.Add(text.gameObject);
    }
}
