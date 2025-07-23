using PassthroughCameraSamples;
using UnityEngine;
using UnityEngine.UI;

public class RenderCanvasPCA : MonoBehaviour
{
    [SerializeField] private RawImage imageDisplay;
    [SerializeField] private WebCamTextureManager webCamTextureManager;

    // Update is called once per frame
    void Update()
    {
        if (webCamTextureManager.WebCamTexture != null)
        {
            imageDisplay.texture = webCamTextureManager.WebCamTexture;
            imageDisplay.material.mainTexture = webCamTextureManager.WebCamTexture;
        }
    }
}