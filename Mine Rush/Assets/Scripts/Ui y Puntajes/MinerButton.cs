using UnityEngine;

public class MinerButton : MonoBehaviour
{
    public GameObject minerPanel;
    public bool IsPanelActive = false;

    private void Update()
    {
        if (IsPanelActive)
        {
            minerPanel.SetActive(true);
        }
        else
        {
            minerPanel.SetActive(false);
        }
    }
    public void ActivatePanel()
    {
        IsPanelActive = true;
    }
}
