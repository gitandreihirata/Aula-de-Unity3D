// Scripts/S_PacmanController.cs
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PacmanController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 input;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(input.x, 0, input.y);
        rb.linearVelocity = dir * speed;

        if (dir != Vector3.zero)
            transform.forward = dir;
    }
}
