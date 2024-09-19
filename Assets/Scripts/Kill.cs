using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Friend")
        {
            GameObject player;
            Debug.Log("Hit " + collision);
            player = collision.gameObject;
            GameManager.gm.Respawn(player);
        }
        else if (collision.transform.tag == "Player" && gameObject.transform.tag == "Reaper")
        {
            Debug.Log("Hit Player");
            CharacterController cc = collision.gameObject.GetComponent<CharacterController>();
            cc.enabled = false;
            GameManager.gm.Respawn(collision.gameObject);
            cc.enabled = true;
        }
    }
}
