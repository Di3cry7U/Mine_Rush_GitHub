using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isInAMenu;
    public GameObject minerButton;

    private void Start()
    {
        isInAMenu = false;
        minerButton.SetActive(false);
    }
    private void Update()
    {
        if (isInAMenu)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
