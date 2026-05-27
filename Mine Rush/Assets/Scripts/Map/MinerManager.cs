using UnityEngine;

public class MinerManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject MinerButton;
    public bool IsPlayerInMinerRange = false;
    public LayerMask layerMask;
    public CameraMovement cameraMovement;
    //public ShopManager shopManager;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        cameraMovement = FindFirstObjectByType<CameraMovement>();
        //shopManager = FindFirstObjectByType<ShopManager>();
        //MinerButton = GameObject.Find("MinerButton");
        //MinerButton.SetActive(false);
    }
    private void Update()
    {
        print(IsPlayerInMinerRange);
        Activation();
        if (IsPlayerInMinerRange /*|| shopManager.IsPlayerInShopRange*/)
        {
           gameManager.minerButton.SetActive(true);
            //cameraMovement.speed = 0f;
        }
        else
        {
            gameManager.minerButton.SetActive(false);
            //cameraMovement.speed = -1f;
        }
    }


    public void Activation()
    {
        Collider2D[] hitcolliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f * 1, 2f * 1),  1f, layerMask);
        IsPlayerInMinerRange = false;

        foreach (var hitcollider in hitcolliders)
        {
            if(hitcollider.CompareTag("Player"))
            {
                IsPlayerInMinerRange = true;
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

    private void OnDestroy()
    {
        MapGenerator mapGenerator = FindAnyObjectByType<MapGenerator>();

        if (mapGenerator != null)
        {
            mapGenerator.MinerDestroyed();
        }
    }






}
