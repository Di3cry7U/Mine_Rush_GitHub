using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DinamiteScript : MonoBehaviour
{
    public LayerMask layerMask;
    public ShopPanel shopPanel;
    public GameObject dinamiteButton;
    public TextMeshProUGUI testTxt;
    public AudioClip tntSfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dinamiteButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        testTxt.text = shopPanel.dinamitePlayerStock.ToString();
        if(shopPanel.dinamitePlayerStock > 0)
        {
            dinamiteButton.SetActive(true);
        }
        else
        {
            dinamiteButton.SetActive(false);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, 2f);
    }
    public void DinamiteExplosion()
    {
        Collider2D[] hitcolliders = Physics2D.OverlapCircleAll(transform.position, 2f, layerMask);
        MusicSFX_Singleton.Instance.SFX(tntSfx);
        foreach (var hitcollider in hitcolliders)
        {
            if (hitcollider.GetComponent<BlockScript>() != null)
            {
                hitcollider.GetComponent<BlockScript>().DropMinerals();
            }
            Destroy(hitcollider.gameObject);


        }
        shopPanel.dinamitePlayerStock--;
    }
}
