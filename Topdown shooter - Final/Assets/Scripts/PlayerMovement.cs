using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);


        //// Realiza un Raycast para detectar colisiones antes de mover al jugador
        //RaycastHit2D hit = Physics2D.Raycast(rb.position, movement, movSpeed * Time.fixedDeltaTime);

        //// Verifica si el Raycast golpea un objeto con el tag "Wall"
        //if (hit.collider != null && hit.collider.CompareTag("Wall"))
        //{
        //    // Si colisiona con un objeto "Wall", ajusta la posición del jugador para evitar quedarse atascado
        //    rb.position = hit.point - (movement * 0.1f);
        //    rb.velocity = Vector2.zero;
        //}
        //else
        //{
        //    // Si no hay colisión con "Wall", permite el movimiento normal
        //    rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
        //}
    }

    // Collisions for collectibles.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("We´ve collected an item!");
            Destroy(collision.gameObject);
        }
    }
}
