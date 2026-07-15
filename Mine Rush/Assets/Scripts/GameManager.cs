using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isInAMenu;
    public GameObject minerButton;
    public GameObject shopButton;
    public GameObject uiGameplay;
    public GameObject startButton;
    public Animator animator;
    public GameObject insButton;
    public GameObject insPanel;

    private void Awake()
    {
        Camera.main.orthographicSize = 800;
        Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.FullScreenWindow);
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
        insButton.SetActive(false);
        animator.SetBool("IsInStart", false);



    }

    public void InstruccionesButton()
    {
        insPanel.SetActive(true);

    }

    public void ExitIns()
    {
        insPanel.SetActive(false);
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
