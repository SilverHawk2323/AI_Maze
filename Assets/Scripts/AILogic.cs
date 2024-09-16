using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AILogic : MonoBehaviour
{
    //Reference to other things
    public GameObject key;
    
    public Player player;

    //Self reference
    public RandomWalk randomWalk;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (door.state == MoveDoor.DoorStates.Locked && key != null)
        {
            _agent.destination = key.position;
        }*/
        /*if (agent.pathPending || !agent.isOnNavMesh || agent.remainingDistance > 0.1f)
        {
            return;
        }
        agent.destination = player.transform.position;*/
    }


    private void OnTriggerEnter(Collider other)
    {
        if (key.gameObject == other.gameObject)//other.GetComponent<Key>() != null)
        {
            other.GetComponent<Key>().OpenDoor();
        }

    }



    public void FollowPlayer()
    {
        if (agent.pathPending || !agent.isOnNavMesh || agent.remainingDistance > 1f || player.firstPerson)
        {
            return;
        }
        agent.destination = player.transform.position;
    }
}
