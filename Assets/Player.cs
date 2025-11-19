using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // MOVEMENT //
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int maxDistance;
    private Vector2 startPosition;
    float h;

    // JUMP //
    [SerializeField] float jumpForce;
    bool isJumping;
    bool isGrounded;

    // INPUT PER GIOCATORE //
    [SerializeField] int playerNumber;
    string orizzontale;
    string salto;


    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        startPosition = rb.position;

        orizzontale = ($"P{playerNumber}Horizontal");
        salto = ($"P{playerNumber}Jump");
    }


    private void Update()
    {
        h = Input.GetAxis(orizzontale);

        if (Input.GetButtonDown(salto) && isGrounded)
        { isJumping = true; }
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



    // CAN JUMP? // ----------------------------------------------------------------------------------------------------------------------------------
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
}

