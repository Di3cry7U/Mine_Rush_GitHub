using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float speed;
    public Rigidbody2D rb;
    public Joystick joystick;

    private float moveInput;

    [Header("Accion Romper")]
    public float dmg = 1f;
    public float cooldown = 0f;
    public float range = 1.2f;
    public LayerMask blockLayer;

    private float nextTimeToDamage = 0f;
    private Vector2 lastDirection = Vector2.right; // dirección por defecto

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Movement(speed);
        GetDirection();

        if (Keyboard.current.spaceKey.isPressed)
        {
            TryBreak();
        }
    }

    void GetInput()
    {
        moveInput = 0f;

        // Teclado
        if (Keyboard.current.aKey.isPressed)
            moveInput -= 1f;

        if (Keyboard.current.dKey.isPressed)
            moveInput += 1f;

        // Joystick virtual
        if (joystick != null)
        {
            moveInput += joystick.Horizontal;
        }

        moveInput = Mathf.Clamp(moveInput, -1f, 1f);
    }

    public void Movement(float _speed)
    {
        rb.linearVelocity = new Vector2(moveInput * _speed, rb.linearVelocity.y);
    }

    public void TryBreak()
    {
        if (Time.time < nextTimeToDamage) return;

        nextTimeToDamage = Time.time + cooldown;

        Debug.DrawRay(transform.position, lastDirection * range, Color.red, 0.5f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, range, blockLayer);

        if (hit.collider != null)
        {
            //print(hit.collider.gameObject.name);
            if (!hit.collider.CompareTag("Player"))
            {
                var block = hit.collider.GetComponent<BlockScript>();
                if (block != null)
                {
                    block.TakeDamage(dmg);
                }
            }
        }
    }

    public void GetDirection()
    {
        Vector2 inputDir = new Vector2(moveInput, 0);

        // Si hay input horizontal → usar izquierda/derecha
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            lastDirection = inputDir.normalized;
        }
        else
        {
            // Si no hay input → mirar hacia abajo
            lastDirection = Vector2.down;
        }
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("GameScene");
    }
}
