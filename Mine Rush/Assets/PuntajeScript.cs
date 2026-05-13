using UnityEngine;

public class PuntajeScript : MonoBehaviour
{

    public float Score;
    public UiManager UiManager;
    float initialPosY;



    private void Start()
    {
        initialPosY = transform.position.y;
        UiManager  = FindAnyObjectByType<UiManager>();
    }


    private void Update()
    {
        ScoreCount();
        print(Score);

    }

    public void ScoreCount()
    {
        float _score;
        _score = Mathf.Abs(transform.position.y - initialPosY);
        Score = (int)_score;
        UiManager.AddPointsToTxt(Score);
    }
}
