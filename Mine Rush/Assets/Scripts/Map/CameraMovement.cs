using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = transform.position += new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }
}
