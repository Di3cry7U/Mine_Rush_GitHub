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
    


    private void Start()
    {
        maxHealth = health;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            DropMinerals();
        }
        txt.text = health.ToString();
    }
    public void TakeDamage(float _damage)
    {
        health -= _damage;
    }

    private void DropMinerals()
    {
        if(gameObject.tag == "Coal")
        {
            Instantiate(coalMinerals, transform.position, transform.rotation);
            print("Dropeado");
        }      
        if(gameObject.tag == "Gold")
        {
            Instantiate(goldMinerals, transform.position, transform.rotation);
            print("Dropeado");
        }        
        if(gameObject.tag == "Redstone")
        {
            Instantiate(redstoneMinerals, transform.position, transform.rotation);
            print("Dropeado");
        }
    }
}
