using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Transform checkpoint;

    private void Start()
    {
        gm = this;
    }

    public void Respawn(GameObject gameobject)
    {
        gameobject.transform.position = checkpoint.position;
    }
}
