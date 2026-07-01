using TMPro;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public TextMeshProUGUI txt;
    public GameObject coalMinerals;
    public GameObject goldMinerals;
    public GameObject redstoneMinerals;

    [Header("Block Sounds")]
    public AudioClip stoneSFX;
    public AudioClip coalSFX;
    public AudioClip goldSFX;
    public AudioClip redstoneSFX;
    public AudioClip indesSFX;
    


    private void Start()
    {
        maxHealth = health;
    }
    private void Update()
    {
        if(gameObject.tag != "Indes")
        {

            if (health <= 0)
            {
                Destroy(gameObject);
                DropMinerals();
            }
            txt.text = health.ToString();
        }
    }
    public void TakeDamage(float _damage)
    {
        health -= _damage;
    }

    public void DropMinerals()
    {
        if(gameObject.tag == "Stone")
        {
            MusicSFX_Singleton.Instance.SFX(stoneSFX);
        }
        if(gameObject.tag == "Coal")
        {
            Instantiate(coalMinerals, transform.position, transform.rotation);
            print("Dropeado");
            MusicSFX_Singleton.Instance.SFX(stoneSFX);
        }      
        if(gameObject.tag == "Gold")
        {
            Instantiate(goldMinerals, transform.position, transform.rotation);
            print("Dropeado");
            MusicSFX_Singleton.Instance.SFX(stoneSFX);
        }        
        if(gameObject.tag == "Redstone")
        {
            Instantiate(redstoneMinerals, transform.position, transform.rotation);
            print("Dropeado");
            MusicSFX_Singleton.Instance.SFX(stoneSFX);
        }
    }
}
