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
}
