using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    private Rigidbody2D swordB;
    Movement player;
    public Transform target;

    Transform firepoint;
    float firepower = 1f;
    float returnpower = 10f;
    float rotateSpeed = 50f;

    void Awake()
    {
        swordB = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            swordB.AddForce(transform.right * 10f, ForceMode2D.Impulse);
            swordB.AddForce(-transform.up * 5f, ForceMode2D.Impulse);
        }

        if(Input.GetButtonDown("Fire2"))
        {
            Vector2 direction = (Vector2)target.position - swordB.position;

            float rotateAmmount = Vector3.Cross(direction, direction).z;

            swordB.angularVelocity = -rotateAmmount * rotateSpeed;

            swordB.velocity = transform.right * returnpower;
            swordB.velocity = -transform.up * returnpower;
        }

        if(Input.GetButtonDown("Retrieve"))
        {
            Destroy(this.gameObject);
            player.ammo = 1;
        }
    }
}
