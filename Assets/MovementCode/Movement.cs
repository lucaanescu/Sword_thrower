using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Animator Animator;

    public Transform firepoint;
    public GameObject Sword;

    private float walk = 5f;
    private float jumpheight = 2f;
    private bool isjump = false;
    private float moveHorizontal;
    private float moveVertical;

    public int ammo = 1;
    private int maxAmmo = 1;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        ammo = 1;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Jump");

        Animator.SetFloat("Speed", Mathf.Abs(moveHorizontal  * walk));

        if(Input.GetButtonDown("Fire1") && ammo > 0)
        {
            //the rest of the shooting code is in SwordScript
            Instantiate(Sword, firepoint.position, firepoint.rotation);
            ammo -= ammo;

            if(moveHorizontal > 0)
            {
                gameObject.transform.localScale = new Vector3(1f,0.45f,1);
            }

            if(moveHorizontal < 0)
            {
                gameObject.transform.localScale = new Vector3(-1f,0.45f,1);
            }
        }
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector3(moveHorizontal  * walk, rb2D.velocity.y, 0);

        if(!isjump && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpheight), ForceMode2D.Impulse);
        }

        if(moveHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(0.45f,0.45f,1);
        }

        if(moveHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-0.45f,0.45f,1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isjump = false;
            Animator.SetBool("Jumping" , false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isjump = true;
            Animator.SetBool("Jumping" , true);
        }
    }
}
