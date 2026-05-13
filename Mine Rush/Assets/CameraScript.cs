using UnityEngine;

public class CameraScript : MonoBehaviour
{
    void Start()
    {
        float targetAspect = 9f / 16f; // tu referencia (vertical)
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera cam = Camera.main;

        if (scaleHeight < 1.0f)
        {
            cam.orthographicSize /= scaleHeight;
        }
    }
}
