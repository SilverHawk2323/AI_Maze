using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject winUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winUI.SetActive(true);
            GameManager.gm.Win();
            Debug.Log("You Win!!!");
        }
    }
}
