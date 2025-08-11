using System.Collections;
using UnityEngine;

/// <summary>
/// Represents a single object detected via Roboflow object detection.
/// Handles enabling/disabling visuals, setting debug text, and auto-hiding after a delay.
/// </summary>
public class RoboflowObject : MonoBehaviour
{
    
    private string @class = "DefaultObjectName"; // The class name of the detected object (e.g. "bear", "panda").

    public int classID = 0;// The class index (optional), e.g. 0 for bear, 1 for panda.

    
    [SerializeField] private float autoDisableDuration = 2f;// Time in seconds before this object hides itself again if not tracked.
    [SerializeField] private GameObject debugTextObject;// Reference to the text GameObject (used to rotate it toward camera).
    [SerializeField] private TMPro.TextMeshProUGUI debugText; // Reference to the TextMeshPro component for displaying debug info.

    private Coroutine autoDisableCoroutine;// Reference to the coroutine used to delay auto-disable.

    /// <summary>
    /// Resets this object to its initial state: disabled, zeroed position and rotation.
    /// Call this before reuse or pooling.
    /// </summary>
    public void Init(string @class, int classId)
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = Vector3.zero;
        this.gameObject.transform.rotation = Quaternion.identity;
        this.@class = @class;
        this.classID = classId;
    }

    public int ClassID
    {
        get => classID;
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

        // Show the object
        this.Enable();

        Debug.Log("I am " + this.gameObject.activeSelf);

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