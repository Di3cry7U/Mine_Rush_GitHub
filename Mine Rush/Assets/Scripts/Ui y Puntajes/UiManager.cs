using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public TextMeshProUGUI mineralsTxt;
    public float mineralsCount;
    public TextMeshProUGUI pointsTxt;
    public float pointsCount;

    [Header("Add Settings")]
    public GameObject addButton;
    public float countAdd = 5f;
    public GameObject addAsset;
    public bool isInAdd = false;

    [Header("Pause Menu")]
    public GameObject pauseCloseButton;
    public GameObject pauseButton;

    public GameManager manager;

    [Header("Defeat Menu")]
    public GameObject defeatPanel;
    public GameObject defeatButton;


    private void Start()
    {
        mineralsTxt.text = "Minerales: " + mineralsCount;
    }
    private void Update()
    {
        mineralsTxt.text = "Minerales: " + mineralsCount;
        print("Anuncio Restante: " + countAdd);
        if (isInAdd)
        {
            addAsset.SetActive(true);
            countAdd -= 0.01f;
        }
        if (countAdd <= 0)
        {
            addAsset.SetActive(false);
            isInAdd =false;
            mineralsCount += 20;
            countAdd = 5f;
        }
    }

    public void AddMineralsToTxt(float _addValue)
    {
        mineralsCount = mineralsCount + _addValue;
        mineralsTxt.text = "Minerales: " + mineralsCount;
    }   
    public void AddPointsToTxt(float _addValue)
    {

        pointsTxt.text = "Puntaje: " + _addValue;

    }   
    public void ExitButton()
    {
        Application.Quit();
    }

    public void PauseButton()
    {
        pauseCloseButton.SetActive(true);
        pauseButton.SetActive(false);
        manager.isInAMenu = true;
    }

    public void CerrarMenuPausa()
    {
        pauseCloseButton.SetActive(false);
        pauseButton.SetActive(true);
        manager.isInAMenu = false;
    }
    public void AddButton()
    {
        isInAdd = true;
        addButton.SetActive(false);
    }

    public void DefeatMenu()
    {
        SceneManager.LoadScene("GameScene");
    }
}
