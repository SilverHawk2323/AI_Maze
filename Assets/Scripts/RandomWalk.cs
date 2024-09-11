using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomWalk : MonoBehaviour
{
    public float _Range = 25.0f;
    NavMeshAgent _Agent;

    void Start()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // == Equal to
        // != NOT equal to
        // < Less than
        // > Greater than
        // <= Less than or Equal to
        // >= Greater than or Equal to
        // && AND
        // || OR

        //if ai is still moving
        if (_Agent.pathPending || !_Agent.isOnNavMesh || _Agent.remainingDistance > 0.1f)
        {
            //exit function (update) here
            return;
        }

        //Choose a random point
        Vector3 randomPosition = _Range * Random.insideUnitCircle;
        randomPosition = new Vector3(randomPosition.x, 0, randomPosition.y);
        _Agent.destination = transform.position + randomPosition;
    }
}
