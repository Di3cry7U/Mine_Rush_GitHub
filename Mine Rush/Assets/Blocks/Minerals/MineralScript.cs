using UnityEngine;

public class MineralScript : MonoBehaviour
{
    public UiManager uiManager;
    public float value;

    private void Start()
    {
        uiManager = FindAnyObjectByType<UiManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            uiManager.AddMineralsToTxt(value);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            uiManager.AddMineralsToTxt(value);
            Destroy(gameObject);
        }
    }
}
