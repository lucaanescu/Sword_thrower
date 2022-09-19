using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float speed = 2f;
    private float distance = 15f;
    private Vector2 moveDir;
    private bool flip;

    //view angles for 
    public float viewRadius;
    public float viewAngle;
    public Vector3 DirFromAngle(float angleInDegrees)
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),Mathf.Cos(angleInDegrees * Mathf.Deg2Rad),0);
    }

    //if player is withing range
    private bool playerr = false;

    //is the ai moving or not
    private bool movingRight = true;

    //player transform
    private Transform Player;

    //checks ground position
    public Transform grounded;

    //skeletons riggid body
    private Rigidbody2D skelly;

    void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        

        if (playerr == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(grounded.position, Vector2.down, distance);

            if(groundInfo.collider == false)
            {
                if(movingRight == true)
                {
                    transform.eulerAngles = new Vector2(0, -180);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector2(0,0);
                    movingRight = true;
                }
            }
        }
        else if (playerr == true)
        {
            Vector3 chase = (Player.position - transform.position).normalized;
            float angle = Mathf.Atan2(chase.z, chase.x) * Mathf.Rad2Deg;
            skelly.rotation = angle;
            moveDir = chase;
            
        }
    }

}
