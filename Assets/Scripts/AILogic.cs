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
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other);
        if (other.GetComponent<Key>())
        {
            other.GetComponent<Key>().OpenDoor();
        }

    }

    public void Dead()
    {
        GameManager.gm.Respawn(gameObject);
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
