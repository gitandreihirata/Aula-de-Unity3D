using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class S_Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody2D rigidbody;

    //Adicionado
    public S_GameManager gameManager;
    public bool isDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        gameManager.GameOver();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
        }
    }
}