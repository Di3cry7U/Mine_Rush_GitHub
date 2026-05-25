using UnityEngine;

public class MinerManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject MinerButton;
    bool IsPlayerInRange = false;
    public LayerMask layerMask;
    public CameraMovement cameraMovement;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        cameraMovement = FindFirstObjectByType<CameraMovement>();
        //MinerButton = GameObject.Find("MinerButton");
        //MinerButton.SetActive(false);
    }
    private void Update()
    {
        print(IsPlayerInRange);
        Activation();
        if (IsPlayerInRange)
        {
           gameManager.minerButton.SetActive(true);
            cameraMovement.speed = 0f;
        }
        else
        {
            gameManager.minerButton.SetActive(false);
            cameraMovement.speed = -1f;
        }
    }


    public void Activation()
    {
        Collider2D[] hitcolliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(3f * 1, 3f * 1),  1f, layerMask);
        IsPlayerInRange = false;

        foreach (var hitcollider in hitcolliders)
        {
            if(hitcollider.CompareTag("Player"))
            {
                IsPlayerInRange = true;
                break;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(
            transform.position,
            new Vector3(2f * 1, 2f * 1, 1f)
        );
    }






}
