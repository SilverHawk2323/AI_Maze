using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Transform checkpoint;
    public Player player;
    public bool pauseGame = false;

    private void Awake()
    {
        if (gm != null)
        {
            Destroy(this);
        }
        else
        {
            gm = this;
        }
    }

    public void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.Win();
        pauseGame = true;
    }

    public void Respawn(GameObject gameobject)
    {
        gameobject.transform.position =  checkpoint.position;
    }
}
