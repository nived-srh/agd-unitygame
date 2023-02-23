using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingMobMovement : MonoBehaviour
{

    // public Transform[] patrolPoints;
    // public int patrolDestination;

    // public Transform obstacle;
    // public bool isChasing;
    // public float chaseDistance;
    // public bool isClose;
    // public Transform playerTransform;
    public Transform feetPosition, middlePosition;
    private Rigidbody2D rb;
    private bool isGrounded, isBlocked;
    public float moveSpeed, groundCheckDistance = 3f;
    public LayerMask platformLayer;
    public int scale = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {

        // // Check if the enemy is moving to the right and flip enemy to the right
        // if (rb.velocity.x > 0)
        // {
        //     transform.localScale = new Vector3(1, 1, 1);
        // }

        // // Check if the enemy is moving to the left and flip enemy to the left
        // if (rb.velocity.x < 0)
        // {
        //     transform.localScale = new Vector3(-1, 1, 1);
        // }

        //Check if above a platform
        Debug.DrawRay(middlePosition.position, Vector2.down * groundCheckDistance, Color.white);
        RaycastHit2D hit = Physics2D.Raycast(feetPosition.position, Vector2.down, groundCheckDistance, platformLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Check if blocked
        Debug.DrawRay(middlePosition.position, Vector2.right * 1f, Color.white);
        RaycastHit2D hitWall = Physics2D.Raycast(middlePosition.position, Vector2.right, 1f, platformLayer);

        if (hitWall.collider != null)
        {
            isBlocked = true;
        }
        else
        {
            isBlocked = false;
        }

        if (!isGrounded || isBlocked)
        {
            scale *= -1;
            transform.localScale = new Vector3(scale, 1, 1);
            moveSpeed *= -1;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        }
    }
}
