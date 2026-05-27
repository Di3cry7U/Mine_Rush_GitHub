using UnityEngine;

public class PuntajeScript : MonoBehaviour
{

    public float Score = 100;
    public UiManager UiManager;
    float initialPosY;
    [Header("Special Spawn")]
    public GameObject shopPrefab;
    public GameObject minerPrefab;

    public int nextSpecialScore = 25;

    private MapGenerator mapGenerator;

    private void Awake()
    {
    }
    private void Start()
    {
        initialPosY = transform.position.y;
        UiManager  = FindAnyObjectByType<UiManager>();
        mapGenerator = FindAnyObjectByType<MapGenerator>();
    }


    private void Update()
    {
        //print(Score);
        ScoreCount();
        CheckSpecialSpawn();
    }

    public void ScoreCount()
    {
        float _score = 0;
        _score = Mathf.Abs(transform.position.y - initialPosY);
        Score = 0 +(int)_score;
        UiManager.AddPointsToTxt(Score);
    }
    void CheckSpecialSpawn()
    {
        if (Score >= nextSpecialScore)
        {
            mapGenerator.ForceNextChunkSpecial();

            nextSpecialScore += 50;
        }
    }

    void SpawnSpecial()
    {
        GameObject selectedPrefab;

        if (Random.value < 0.5f)
        {
            selectedPrefab = shopPrefab;
        }
        else
        {
            selectedPrefab = minerPrefab;
        }

        Vector2 spawnPos = new Vector2(
            transform.position.x,
            transform.position.y - 15f
        );

        Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
    }
}
