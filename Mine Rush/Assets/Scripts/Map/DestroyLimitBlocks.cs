using UnityEngine;

public class DestroyLimitBlocks : MonoBehaviour
{
    public GameManager manager;
    public UiManager uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            manager.isInAMenu = true;
            uiManager.defeatPanel.SetActive(true);
        }
        else
        {
            Destroy(collision.gameObject);

        }
    }
}
