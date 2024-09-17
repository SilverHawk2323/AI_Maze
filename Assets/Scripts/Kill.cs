using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameObject player;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Friend")
        {
            Debug.Log("Hit " + collision);
            player = collision.gameObject;
            GameManager.gm.Respawn(player);
        }
        else if (collision.transform.tag == "Player" && gameObject.transform.tag == "Reaper")
        {
            GameManager.gm.Respawn(collision.gameObject);
        }
    }

    private void KillCollision(GameObject other)
    {
        
    }
}
