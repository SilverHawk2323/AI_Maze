using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*

When the object is at one point it needs to move to the other after a bit of time

A function called when the object touches a collider from either point A or B that tells the object to turn around and head to another direction





*/
enum Waypoints
{
    pointA, pointB, currentPoint
}
[RequireComponent(typeof(NavMeshAgent))]
public class MovingObject : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform currentPoint;
    public float speed;
    private NavMeshAgent agent;

    public Rigidbody rb;
    private Waypoints waypoints = Waypoints.pointA;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointA;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (waypoints)
        {
            case Waypoints.pointA:
                agent.destination = pointA.position; 
                break;

            case Waypoints.pointB:
                agent.destination = pointB.position;
                break;
        }
        
    }

    /*void Movement(Transform point)
    {
        Vector2 direction = point.position - transform.position;

        direction.Normalize();

        direction = direction * speed * Time.deltaTime;

        transform.position = transform.position + (Vector3)direction;
    }*/

    private void OnTriggerEnter(Collider collision)
    {
        
        
            if (waypoints == Waypoints.pointB)
            {
                waypoints = Waypoints.pointA;
            }
            else
            {
                waypoints = Waypoints.pointB;
            }
        

    }
}
