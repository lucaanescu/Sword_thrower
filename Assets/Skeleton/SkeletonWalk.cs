using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWalk : MonoBehaviour
{
    private float walkSpeed = 200;
    public float range, distToPlayer;

    public bool mustTurn;
    public bool mustPatrol;
    public Rigidbody2D rb;
    public Transform groundCheckPos, player;
    public Collider2D bodyCollider;

    public LayerMask groundLayer;

    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn || bodyCollider.IsTouchingLayers())
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}