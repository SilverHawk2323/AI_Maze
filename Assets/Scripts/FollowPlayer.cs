using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    
[RequireComponent (typeof (NavMeshAgent))] 

public class FollowPlayer : MonoBehaviour
{


    public Transform goal;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathPending || !agent.isOnNavMesh || agent.remainingDistance > 0.1f)
        {
            return;
        }
        agent.destination = goal.position;
    }
}
