using UnityEngine;

/// <summary>
/// Handles basic Hand / Controller input.
/// </summary>
public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject centerEyeAnchor; // Reference to the center eye anchor in the CameraRig
    [SerializeField] private GameObject gui; // Reference to the GUI GameObject

    void Update()
    {
        // Open / Close GUI
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (!this.gui.activeSelf)
            {
                gui.transform.position = centerEyeAnchor.transform.position + centerEyeAnchor.transform.forward * 0.6f;
                gui.transform.rotation = Quaternion.LookRotation(gui.transform.position - centerEyeAnchor.transform.position);
                gui.SetActive(true);
            }
            else
            {
                gui.SetActive(false);
            }
        }
    }
}