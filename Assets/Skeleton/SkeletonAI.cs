using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    private float cooldownTimer = Mathf.Infinity;

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= attackCooldown){
            //Attack here
        }
    }
}
