using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int playerNumber;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int maxDistance;
    private Vector2 startPosition;
    float h;

    [SerializeField] float jumpForce;
    bool isJumping;
    bool isGrounded;




    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        startPosition = rb.position;
    }



    private void Update()
    {
        if (playerNumber == 1)
        {
            h = Input.GetAxis("P1Horizontal");

            if (Input.GetButtonDown("P1Jump") && isGrounded)
            { isJumping = true; }
        }
        else if (playerNumber == 2)
        {
            h = Input.GetAxis("P2Horizontal");

            if (Input.GetButtonDown("P2Jump") && isGrounded)
            { isJumping = true; }
        }
        else
        { Debug.LogError("IL NUMERO DEL PLAYER É ERRATO 1 o 2"); }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        { isGrounded = true; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        { isGrounded = false; }
    }


    private void FixedUpdate()
    {
        // MOVEMENT // -------------------------------------------------------------------------------------------------------------------------------
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (Vector2.Distance(startPosition, rb.position) > maxDistance)
        { rb.position = startPosition; }



        // JUMP // -----------------------------------------------------------------------------------------------------------------------------------
        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
        }
    }
}

