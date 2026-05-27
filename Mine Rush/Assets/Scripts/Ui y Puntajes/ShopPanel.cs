using TMPro;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{

    public GameManager manager;
    public ShopButton cerrarButton;
    public TextMeshProUGUI costoTxtPowUpTaladro;
    public float costPowUpTal = 20;
    public TextMeshProUGUI costoTxtPowUpDin;
    public float costPowUpDin = 20;
    public UiManager mineralsManager;
    public PlayerMovement playerStats;

    private void OnEnable()
    {
        manager.isInAMenu = true;
    }
    private void Start()
    {
        costoTxtPowUpTaladro.text = ": " + costPowUpTal;
    }
    private void Update()
    {
        costoTxtPowUpTaladro.text = ": " + costPowUpTal;
    }

    public void CloseMinerMenu()
    {
        cerrarButton.IsPanelActive = false;
    }

    private void OnDisable()
    {
        manager.isInAMenu = false;
    }


    public void ComprarPowUpTal()
    {
        if (mineralsManager.mineralsCount >= costPowUpTal)
        {
            print("Compraste Power-Up De Taladro");
        }
    }   
    public void ComprarPowUpDin()
    {
        if (mineralsManager.mineralsCount >= costPowUpDin)
        {

        }
    }
}


