using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float speed = 2f;
    private float distance = 15f;

    bool noplayer = true;

    private bool movingRight = true;

    public Transform grounded;

    private Rigidbody2D skelly;

    void Awake()
    {
        
    }

    void Update()
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

}
