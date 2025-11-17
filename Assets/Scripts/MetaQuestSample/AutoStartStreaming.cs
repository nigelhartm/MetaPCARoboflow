using System.Collections;
using UnityEngine;

public class AutoStartStreaming : MonoBehaviour
{
    public RoboflowCaller roboflowCaller;   // assign in Inspector
    public float delay = 5f;                // 5 seconds

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        roboflowCaller.onStreamingButtonCLicked();
    }
}
