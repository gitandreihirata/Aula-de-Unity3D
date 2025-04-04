using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject head;
    public GameObject body;
    public float speed = 3f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public string characterType;
    private Animator animatorHead;
    private Animator animatorBody;

    private Vector2 moveInput;
    private bool jumpInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorHead = head.GetComponent<Animator>();
        animatorBody = body.GetComponent<Animator>();
    }

    void Update()
    {
        // Movimento
        float move = moveInput.x * speed;
        rb.linearVelocity = new Vector2(move, rb.linearVelocity.y);

        if (Mathf.Abs(move) > 0.1f)
        {
            animatorHead.SetBool("isWalking", true);
            animatorBody.SetBool("isWalking", true);
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }
        else
        {
            animatorHead.SetBool("isWalking", false);
            animatorBody.SetBool("isWalking", false);
        }

        // Pulo
        if (jumpInput && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            jumpInput = false; // reset após uso
        }
    }

    // Métodos de input (configurado via PlayerInput - Unity Events)
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            jumpInput = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {/*
        if ((characterType == "Fire" && collision.CompareTag("Water")) ||
            (characterType == "Water" && collision.CompareTag("Fire")) ||
            collision.CompareTag("Goo"))
        {
            //animatorHead.SetTrigger("Dying");
            Destroy(gameObject, 0.5f); // Pequeno atraso para mostrar anima��o de morte
        }*/
    }
}
