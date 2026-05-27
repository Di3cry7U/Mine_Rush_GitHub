using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject ShopButton;
    public bool IsPlayerInShopRange = false;
    public LayerMask layerMask;
    public CameraMovement cameraMovement;
    //public MinerManager minerManager;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        cameraMovement = FindFirstObjectByType<CameraMovement>();
        //minerManager = FindFirstObjectByType<MinerManager>();
        //MinerButton = GameObject.Find("MinerButton");
        //MinerButton.SetActive(false);
    }
    private void Update()
    {
        print(IsPlayerInShopRange);
        Activation();
        if (IsPlayerInShopRange /*|| minerManager.IsPlayerInMinerRange*/)
        {
            gameManager.shopButton.SetActive(true);
            //cameraMovement.speed = 0f;
        }
        else
        {
            gameManager.shopButton.SetActive(false);
            //cameraMovement.speed = -1f;
        }
    }


    public void Activation()
    {
        Collider2D[] hitcolliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f * 1, 2f * 1), 1f, layerMask);
        IsPlayerInShopRange = false;

        foreach (var hitcollider in hitcolliders)
        {
            if (hitcollider.CompareTag("Player"))
            {
                IsPlayerInShopRange = true;
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
            mapGenerator.ShopDestroyed();
        }
    }






}
