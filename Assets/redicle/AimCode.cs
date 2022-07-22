using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCode : MonoBehaviour
{
        public GameObject sword;
        private float launchForce = 50f;
        public Transform shotPoint;
        private Vector2 targetPos;
        public float followspeed = 2.0f;

    void Awake()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        //for the reticle to rotate to the mouse
        Vector2 RetPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Redirect = mousePos - RetPos;
        transform.right = Redirect;

        //for the reticle to follow the mouse position
        float distance = transform.position.z + Camera.main.transform.position.z;
        targetPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);

        //it follows at a slow speed
        Vector2 followXonly = new Vector2(targetPos.x, targetPos.y);
        transform.position = Vector2.Lerp (transform.position, followXonly, followspeed * Time.deltaTime);
    }
}
