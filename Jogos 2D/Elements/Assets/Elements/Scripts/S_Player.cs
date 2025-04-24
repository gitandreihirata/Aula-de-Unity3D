using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class S_Player : MonoBehaviour
{
    public GameObject head;
    public GameObject body;
    public float speed = 3f;
    public float jumpForce = 5f;
    public string characterType;

    private Rigidbody2D rb;
    private Animator animatorHead;
    private Animator animatorBody;
    private Vector2 moveInput;
    private bool jumpInput;
    private bool isGrounded;

    public AudioClip deathSound;
    private AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorHead = head.GetComponent<Animator>();
        animatorBody = body.GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        Debug.Log("S_Player awake on: " + gameObject.name);
        Debug.Log("Has method OnMove? " + (GetType().GetMethod("OnMove") != null));
        Debug.Log("Has method OnJump? " + (GetType().GetMethod("OnJump") != null));
    }

    void Update()
    {
        float move = moveInput.x * speed;
        rb.linearVelocity = new Vector2(move, rb.linearVelocity.y);

        animatorHead.SetBool("isWalking", Mathf.Abs(move) > 0.1f);
        animatorBody.SetBool("isWalking", Mathf.Abs(move) > 0.1f);

        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);

        if (jumpInput && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            jumpInput = false;
        }
    }

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
    {
        if ((characterType == "FireMan" && collision.CompareTag("WaterPuddle")) ||
            (characterType == "WaterGirl" && collision.CompareTag("FirePuddle")) ||
            collision.CompareTag("AcidPuddle"))
        {
            animatorHead.SetTrigger("isDead");
            animatorBody.SetTrigger("isDead");

            if (deathSound != null && audioSource != null)
                audioSource.PlayOneShot(deathSound);

            // Desativa movimentação
            this.enabled = false;
            Destroy(gameObject, 0.5f);

            // Chamar painel de derrota
            Object.FindFirstObjectByType<S_GameUIManager>().ShowLoseScreen();
        }
    }

}

public static class InputPreserveWorkaround
{
    [RuntimeInitializeOnLoadMethod]
    static void PreserveMethods()
    {
        var dummy = new S_Player();
        dummy.OnMove(default);
        dummy.OnJump(default);
    }
}