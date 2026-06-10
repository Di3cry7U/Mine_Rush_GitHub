using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float targetWidth = 5.9f;
    private void Start()
    {
        Camera cam = GetComponent<Camera>();
        float aspect = (float)Screen.width / Screen.height;
        cam.orthographicSize = targetWidth/(2* aspect);
    }


    //void Start()
    //{
    //    float targetAspect = 9f / 16f; // tu referencia (vertical)
    //    float windowAspect = (float)Screen.width / Screen.height;
    //    float scaleHeight = windowAspect / targetAspect;

    //    Camera cam = Camera.main;

    //    if (scaleHeight < 1.0f)
    //    {
    //        cam.orthographicSize /= scaleHeight;
    //    }
    //}
}
