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
    public float taladroPlayerStock;
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
        costoTxtPowUpTaladro.text = ": " + costPowUpTal;
        costoTxtPowUpDin.text = ": " + costPowUpDin;
    }
    private void Update()
    {
        costoTxtPowUpTaladro.text = ": " + costPowUpTal;
            costoTxtPowUpDin.text = ": " + costPowUpDin;

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


    public void ComprarPowUpTal()
    {
        if (mineralsManager.mineralsCount >= costPowUpTal)
        {
            taladroPlayerStock += 1;
            mineralsManager.mineralsCount = mineralsManager.mineralsCount - costPowUpTal;
            costPowUpTal *= 1.5f;
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

    public void AddButton()
    {
        isInAdd = true;
        addButton.SetActive(false);
    }
}


