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
    public float dinamitePlayerStock;
    public UiManager mineralsManager;
    public PlayerMovement playerStats;

    private void OnEnable()
    {
        manager.isInAMenu = true;
    }
    private void Start()
    {
        costoTxtPowUpTaladro.text = ": " + costPowUpTal;
        costoTxtPowUpDin.text = ": " + costPowUpDin;
    }
    private void Update()
    {
        costoTxtPowUpTaladro.text = ": " + costPowUpTal;
            costoTxtPowUpDin.text = ": " + costPowUpDin;
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

            costoTxtPowUpTaladro.text = ": " + costPowUpTal;
        }
    }   
    public void ComprarPowUpDin()
    {
        if (mineralsManager.mineralsCount >= costPowUpDin)
        {
            dinamitePlayerStock+=1;
            mineralsManager.mineralsCount = mineralsManager.mineralsCount - costPowUpDin;
            costPowUpDin *= 1.5f;

        }
    }
}


