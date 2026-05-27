using UnityEngine;
using UnityEngine.EventSystems;

public class MiningButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerMovement player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.isMining = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.isMining = false;
    }
}
