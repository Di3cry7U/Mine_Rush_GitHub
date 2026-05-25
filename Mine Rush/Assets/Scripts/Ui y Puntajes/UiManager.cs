using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    public TextMeshProUGUI mineralsTxt;
    public float mineralsCount;
    public TextMeshProUGUI pointsTxt;
    public float pointsCount;

    private void Start()
    {
        mineralsTxt.text = "Minerales: " + mineralsCount;
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
}
