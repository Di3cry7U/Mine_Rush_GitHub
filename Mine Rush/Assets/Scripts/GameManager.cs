using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isInAMenu;
    public GameObject minerButton;
    public GameObject shopButton;
    public GameObject uiGameplay;
    public GameObject startButton;
    public Animator animator;

    private void Awake()
    {
        Camera.main.orthographicSize = 800;
    }
    private void Start()
    {
        //isInAMenu = false;
        minerButton.SetActive(false);
        shopButton.SetActive(false);
    }


    public void ButtonStart()
    {
        isInAMenu = false;
        startButton.SetActive(false);
        animator.SetBool("IsInStart", false);

    }
    private void Update()
    {
        if (isInAMenu)
        {
            Time.timeScale = 0f;
            uiGameplay.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            uiGameplay.SetActive(true);
        }
    }
}
