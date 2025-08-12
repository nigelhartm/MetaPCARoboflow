using System.Collections;
using UnityEngine;

/// <summary>
/// Represents a single object detected via Roboflow object detection.
/// Handles enabling/disabling visuals, setting debug text, and auto-hiding after a delay.
/// </summary>
public class RoboflowObject : MonoBehaviour
{
    [Header("Roboflow Object Settings")]
    [SerializeField] private float autoDisableDuration = 2f; // Time in seconds before this object hides itself again if not tracked.
    [SerializeField] private GameObject debugTextObject; // Reference to the text GameObject (used to rotate it toward camera).
    [SerializeField] private TMPro.TextMeshProUGUI debugText; // Reference to the TextMeshPro component for displaying debug info.

    private string @class = "DefaultObjectName"; // The class name of the detected object (e.g. "bear", "panda").
    public int classID = 0; // The class index (optional), e.g. 0 for bear, 1 for panda.
    private Coroutine autoDisableCoroutine; // Reference to the coroutine used to delay auto-disable.

    /// <summary>
    /// Resets this object to its initial state: disabled, zeroed position and rotation.
    /// </summary>
    public void Init(string @class, int classId)
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = Vector3.zero;
        this.gameObject.transform.rotation = Quaternion.identity;
        this.@class = @class;
        this.classID = classId;
    }

    /// <summary>
    /// Gets the class name of this object.
    /// </summary>
    public int ClassID
    {
        get => classID;
    }

    /// <summary>
    /// Sets the debug label text
    /// </summary>
    public void SetDebugText(string text)
    {
        if (debugText != null)
        {
            debugText.text = text;
        }
    }

    /// <summary>
    /// Enables the object
    /// </summary>
    public void Enable()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Disables the object
    /// </summary>
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Called whenever this object was successfully detected and updated.
    /// </summary>
    /// <param name="position">World position where object was detected.</param>
    /// <param name="CameraPosition">Camera position to face the label toward.</param>
    public void SuccesfullyTracked(Vector3 position, Vector3 CameraPosition)
    {
        this.gameObject.transform.position = position;
        this.debugTextObject.transform.rotation = Quaternion.LookRotation(debugTextObject.transform.position - CameraPosition);
        this.Enable();

        if (autoDisableCoroutine != null)
        {
            StopCoroutine(autoDisableCoroutine);
        }

        autoDisableCoroutine = StartCoroutine(AutoDisableAfterDelay());
    }

    /// <summary>
    /// Coroutine that waits a few seconds and then disables the object.
    /// </summary>
    private IEnumerator AutoDisableAfterDelay()
    {
        yield return new WaitForSeconds(autoDisableDuration);
        Disable();
    }
}