using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Destroy : MonoBehaviour
{
    //public float dmg = 1f;
    //public float cooldown = 0.5f;

    //private float nextTimeToDamage = 0f;

    //void Update()
    //{
    //    if (Pointer.current != null && Pointer.current.press.isPressed && Time.time >= nextTimeToDamage)
    //    {
    //        Vector2 screenPos = Pointer.current.position.ReadValue();

    //        // 🚫 BLOQUEAR zona inferior (donde está el joystick)
    //        if (screenPos.y < Screen.height * 0.2f)
    //            return;

    //        nextTimeToDamage = Time.time + cooldown;

    //        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

    //        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

    //        if (hit.collider != null)
    //        {
    //            if (!hit.collider.CompareTag("Player"))
    //            {
    //                var block = hit.collider.GetComponent<BlockScript>();
    //                if (block != null)
    //                {
    //                    block.TakeDamage(dmg);
    //                }
    //            }
    //        }
    //    }
    //}
    public float dmg = 1f;
    public float cooldown = 0.5f;
    public float range = 1.2f;

    private float nextTimeToDamage = 0f;
    private Vector2 lastDirection = Vector2.right; // dirección por defecto

    //public void GetDirection()
    //{
    //    Vector2 inputDir = new Vector2(moveInput, 0);

    //    // Guardar última dirección válida
    //    if (inputDir.magnitude > 0.1f)
    //    {
    //        lastDirection = inputDir.normalized;
    //    }
    //}
}
