using System.Collections;
using UnityEngine;

public class RF_Object : MonoBehaviour
{
    [SerializeField] private string @class = "DefaultObjectName";
    [SerializeField] private int classID = 0;
    [SerializeField] private TMPro.TextMeshProUGUI debugText;
    [SerializeField] private float autoDisableDuration = 2f;
    private Coroutine autoDisableCoroutine;

    // Public property to access classID
    public int ClassID
    {
        get => classID;
        set => classID = value;
    }

    public void Init()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = Vector3.zero;
        this.gameObject.transform.rotation = Quaternion.identity;
    }

    public void Enable()
    {
        this.gameObject.SetActive(true);
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void SetDebugText(string text)
    {
        if (debugText != null)
        {
            debugText.text = text;
        }
    }

    public void SuccesfullyTracked(Vector3 position) {
        this.gameObject.transform.position = position;
        this.Enable();

        // Restart the auto-disable timer
        if (autoDisableCoroutine != null)
        {
            StopCoroutine(autoDisableCoroutine);
        }
        autoDisableCoroutine = StartCoroutine(AutoDisableAfterDelay());
    }
    private IEnumerator AutoDisableAfterDelay()
    {
        yield return new WaitForSeconds(autoDisableDuration);
        Disable();
    }
}
