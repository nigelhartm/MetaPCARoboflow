using System.Collections;
using UnityEngine;

/// <summary>
/// Represents a single object detected via Roboflow object detection.
/// Handles enabling/disabling visuals, setting debug text, and auto-hiding after a delay.
/// </summary>
public class RoboflowObject : MonoBehaviour
{
    // The class name of the detected object (e.g. "bear", "panda").
    [SerializeField] private string @class = "DefaultObjectName";

    // The class index (optional), e.g. 0 for bear, 1 for panda.
    [SerializeField] private int classID = 0;

    // Reference to the text UI component used for showing debug/class info.
    [SerializeField] private TMPro.TextMeshProUGUI debugText;

    // Reference to the text GameObject (used to rotate it toward camera).
    [SerializeField] private GameObject debugTextObject;

    // Time in seconds before this object hides itself again if not tracked.
    [SerializeField] private float autoDisableDuration = 2f;

    // Reference to the coroutine used to delay auto-disable.
    private Coroutine autoDisableCoroutine;

    /// <summary>
    /// Public getter and setter for the object's class ID.
    /// </summary>
    public int ClassID
    {
        get => classID;
        set => classID = value;
    }

    /// <summary>
    /// Resets this object to its initial state: disabled, zeroed position and rotation.
    /// Call this before reuse or pooling.
    /// </summary>
    public void Init()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = Vector3.zero;
        this.gameObject.transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// Enables the object (e.g. when newly detected or reused).
    /// </summary>
    public void Enable()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Disables the object (e.g. when not detected anymore).
    /// </summary>
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the debug label text (e.g. class name + confidence).
    /// </summary>
    public void SetDebugText(string text)
    {
        if (debugText != null)
        {
            debugText.text = text;
        }
    }

    /// <summary>
    /// Called whenever this object was successfully detected and updated.
    /// Updates its position and rotates the label to face the camera.
    /// Also restarts the timer to auto-hide the object after some time.
    /// </summary>
    /// <param name="position">World position where object was detected.</param>
    /// <param name="CameraPosition">Camera position to face the label toward.</param>
    public void SuccesfullyTracked(Vector3 position, Vector3 CameraPosition)
    {
        // Move object to the detected position
        this.gameObject.transform.position = position;

        // Rotate the debug text to face the camera
        this.debugTextObject.transform.rotation = Quaternion.LookRotation(debugTextObject.transform.position - CameraPosition);

        // Show the object
        this.Enable();

        // Restart the auto-disable timer
        if (autoDisableCoroutine != null)
        {
            StopCoroutine(autoDisableCoroutine);
        }
        autoDisableCoroutine = StartCoroutine(AutoDisableAfterDelay());
    }

    /// <summary>
    /// Coroutine that waits a few seconds and then disables the object.
    /// Used to hide objects that are no longer being detected.
    /// </summary>
    private IEnumerator AutoDisableAfterDelay()
    {
        yield return new WaitForSeconds(autoDisableDuration);
        Disable();
    }
}
