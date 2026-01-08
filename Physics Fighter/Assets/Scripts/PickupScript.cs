using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PickupScript : MonoBehaviour
{
    public Collider2D[] objects;
    public bool selecting;
    public float distance = 100;
    public GameObject closest;
    public GameObject target;
    public Rigidbody2D rb;
    public float targetDisX;
    public float targetDisY;
    public LayerMask castLayerMask;
    public Vector2 worldPosition;
    public float targetAngle;
    public Vector2 hitDirection;
    public float hitDistance;
    public float pullMult;
    void Start()
    {
        selecting = true;
    }

    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1) == true && selecting == true)
        {
            objects = Physics2D.OverlapCircleAll(worldPosition, 1f,castLayerMask);
            {
                
                if(objects.Length>=0)
                {
                    for (int i = 0; i < objects.Length; i++)
                    {                
                        if(distance> Vector2.Distance(worldPosition, objects[i].transform.position))
                        { 
                            closest = objects[i].gameObject; 
                        }

                    }
                }
            }
            if (closest != null)
            {
                target = closest;
                selecting = false;
            }
        }
        if (selecting == false && target != null)
        {
            rb = target.GetComponent<Rigidbody2D>();
            targetDisX = worldPosition.x - target.transform.position.x;
            targetDisY = worldPosition.y - target.transform.position.y;
            targetAngle = Vector2.Angle(new Vector2(worldPosition.x, target.transform.position.x), new Vector2(worldPosition.y, target.transform.position.y));
            Debug.Log(targetAngle);
            rb.AddForce(new Vector2(targetDisX * Time.deltaTime, targetDisY * Time.deltaTime));


            hitDirection = new Vector2(target.transform.position.x, target.transform.position.y) - worldPosition;
            hitDistance = Vector2.Distance(worldPosition, new Vector2(target.transform.position.x, target.transform.position.y));
            rb.AddForce(((hitDirection * (-40 * (1 / (hitDistance * 10)))) * Time.deltaTime) * pullMult);
        }


        /* 
         //Find signed angle
         * Vector2 direction = new Vector2(target.transform.position.x , target.transform.position.y) - worldPosition;
         float signedAngleRad = Mathf.Atan2(direction.y, direction.x);
         float signedAngleDeg = signedAngleRad * Mathf.Rad2Deg;
         Debug.Log(signedAngleDeg);*/


    }
}
