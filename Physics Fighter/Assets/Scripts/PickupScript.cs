using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PickupScript : MonoBehaviour
{
    public RaycastHit2D[] objects;
    public bool selecting;
    public float distance;
    public GameObject closest;
    public GameObject target;
    public Rigidbody2D rb;
    public float targetDisX;
    public float targetDisY;
    void Start()
    {
        selecting = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) == true && selecting == true)
        {
            objects = Physics2D.CircleCastAll(Input.mousePosition, 0.1f, new Vector2(0, 0), 0);
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if (i == 0)
                    {
                        distance = Vector2.Distance(Input.mousePosition, objects[i].transform.position);
                        closest = objects[i].collider.gameObject;
                    }
                    else if (i != 0 && Vector2.Distance(Input.mousePosition, objects[i].transform.position) < distance)
                    {
                        distance = Vector2.Distance(Input.mousePosition, objects[i].transform.position);
                        closest = objects[i].collider.gameObject;
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
            targetDisX = Input.mousePosition.x - target.transform.position.x;
            targetDisY = Input.mousePosition.y - target.transform.position.y;
            rb.AddForce(new Vector2(targetDisX * Time.deltaTime, targetDisY * Time.deltaTime));
        }
    }
}
