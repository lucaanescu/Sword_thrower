using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    private Rigidbody2D swordB;
    Movement player;
    AimCode aim;

    Transform firepoint;
    float firepower = 5f;
    float returnpower = 50f;
    float rotateSpeed = 50f;

    private Transform targetPos;

    void Awake()
    {
        swordB = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        aim = GameObject.FindGameObjectWithTag("Redicle").GetComponent<AimCode>();
        targetPos = GameObject.FindGameObjectWithTag("Redicle").GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 direction = (Vector2)targetPos.position - swordB.position;
        
        float rotate = Vector3.Cross(direction, transform.right).z;

        swordB.angularVelocity = -rotate * rotateSpeed;

        swordB.angularVelocity = -rotate * rotateSpeed;

        if(Input.GetButtonDown("Fire1"))
        {
            swordB.velocity = transform.right * firepower;
            Debug.Log("I fired my sword");
            //swordB.AddForce(transform.right * 10f, ForceMode2D.Impulse);  # old script that migth get put back but for now it made the sword flail around too much
        }

        if(Input.GetButtonDown("Fire2"))
        {
            
        }

        if(Input.GetButtonDown("Retrieve"))
        {
            Destroy(this.gameObject);
            player.ammo = 1;
        }
    }
}
