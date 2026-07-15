using TMPro;
using UnityEngine;

public class MinerPanel : MonoBehaviour
{
    public GameManager manager;
    public MinerButton cerrarButton;
    public TextMeshProUGUI costoTxtMejVel;
    public float costMejVel = 20;
    public TextMeshProUGUI costoTxtMejDan;
    public float costMejDan = 20;
    public UiManager mineralsManager;
    public PlayerMovement playerStats;

    [Header("Add Settings")]
    public GameObject addButton;
    public float countAdd = 5f;
    public GameObject addAsset;
    public bool isInAdd = false;

    private void OnEnable()
    {
        manager.isInAMenu = true;
    }
    private void Start()
    {
        costoTxtMejVel.text = ": " + costMejVel;
        costoTxtMejDan.text = ": " + costMejDan;
    }
    private void Update()
    {
        costoTxtMejVel.text = ": " + costMejVel;
        costoTxtMejDan.text = ": " + costMejDan;

        if (isInAdd)
        {
            addAsset.SetActive(true);
            countAdd -= 0.01f;
        }
        if (countAdd <= 0)
        {
            addAsset.SetActive(false);
            isInAdd = false;
            mineralsManager.mineralsCount += 20;
            countAdd = 5f;
        }
    }

    public void CloseMinerMenu()
    {
        cerrarButton.IsPanelActive = false;
    }

    private void OnDisable()
    {
        manager.isInAMenu = false;
    }


    public void MejorarVelocidad()
    {
        if (mineralsManager.mineralsCount >= costMejVel)
        {
            playerStats.cooldown -= .1f;
            mineralsManager.mineralsCount = mineralsManager.mineralsCount -= costMejVel;
            costMejVel *= 2f;
        }
    }
    public void MejorarDaño()
    {
        if (mineralsManager.mineralsCount >= costMejDan)
        {
            playerStats.dmg += 1f;
            mineralsManager.mineralsCount = mineralsManager.mineralsCount -= costMejDan;
            costMejDan *= 2f;
        }
    }

    public void AddButton()
    {
        isInAdd = true;
        addButton.SetActive(false);
    }
}
