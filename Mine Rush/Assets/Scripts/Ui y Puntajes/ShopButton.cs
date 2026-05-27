using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject shopPanel;
    public bool IsPanelActive = false;

    private void Update()
    {
        if (IsPanelActive)
        {
            shopPanel.SetActive(true);
        }
        else
        {
            shopPanel.SetActive(false);
        }
    }
    public void ActivatePanel()
    {
        IsPanelActive = true;
    }
}
