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
    public LayerMask castLayerMask;
    public Vector2 worldPosition;
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

            hitDirection = new Vector2(target.transform.position.x, target.transform.position.y) - worldPosition;
            hitDistance = Vector2.Distance(worldPosition, new Vector2(target.transform.position.x, target.transform.position.y));
            rb.AddForce((hitDirection * -(hitDistance) * Time.deltaTime) * pullMult);
        }
    }
}
