using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCol.bounds.size.x * range, boxCol.bounds.size.y, boxCol.bounds.size.z),
        0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCol.bounds.size.x * range, boxCol.bounds.size.y, boxCol.bounds.size.z));
    }

}
