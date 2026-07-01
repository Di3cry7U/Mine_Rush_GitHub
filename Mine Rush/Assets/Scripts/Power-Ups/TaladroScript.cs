using TMPro;
using UnityEngine;

public class TaladroScript : MonoBehaviour
{
    public LayerMask layerMask;
    public ShopPanel shopPanel;
    public GameObject TaladroButton;
    public GameObject player;
    public PlayerMovement playerScript;
    public bool taladroActive = false;
    float activeTime  = 3;
    float lastCooldown;
    public AudioClip taladroClip;

    void Start()
    {
        TaladroButton.SetActive(false);
        lastCooldown = playerScript.cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (shopPanel.taladroPlayerStock > 0)
        {
            TaladroButton.SetActive(true);
        }
        else
        {
            TaladroButton.SetActive(false);
        }
        if (taladroActive)
        {
            activeTime -= 0.008f;
            playerScript.cooldown = .1f;
        }

        if(activeTime <= 0) 
        {
            MusicSFX_Singleton.Instance.sourceSFX.Stop();
            playerScript.cooldown = lastCooldown;
            taladroActive = false;
            activeTime = 3;
        }
        print(activeTime);
    }

    public void TaladroActivator()
    {
        taladroActive = true;
        shopPanel.taladroPlayerStock -= 1;
        MusicSFX_Singleton.Instance.SFX(taladroClip);
        //RaycastHit2D[] hits = Physics2D.RaycastAll(player.transform.position, Vector2.down, );
    }
}
