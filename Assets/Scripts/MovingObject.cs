using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

When the object is at one point it needs to move to the other after a bit of time

A function called when the object touches a collider from either point A or B that tells the object to turn around and head to another direction





*/

public class MovingObject : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform currentPoint;
    public float speed;

    public Rigidbody rb;

    enum Waypoints
    {
        pointA, pointB, currentPoint
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(currentPoint);
    }

    void Movement(Transform point)
    {
        Vector2 direction = point.position - transform.position;

        direction.Normalize();

        direction = direction * speed * Time.deltaTime;

        transform.position = transform.position + (Vector3)direction;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hit something");
        if (collision.transform.tag == "Waypoint")
        {
            if (currentPoint == pointA)
            {
                currentPoint = pointB;
                Debug.Log("Reached Point A");
            }
            else
            {
                currentPoint = pointA;
            }

        }

    }
}
