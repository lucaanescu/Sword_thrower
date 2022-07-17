using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    private Rigidbody2D swordB;
    Movement player;

    Transform firepoint;
    float firepower = 1f;

    void Awake()
    {
        swordB = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            swordB.AddForce(transform.right * 40f, ForceMode2D.Impulse);
        }

        if(Input.GetButtonDown("Fire2"))
        {
            Destroy(this.gameObject);
            player.ammo = 1;
        }
    }
}
