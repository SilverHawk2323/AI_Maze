using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public GameObject obstacle;
    [SerializeField] private Vector3 openPosition = new Vector3(0f, -5f, 0f);
    [SerializeField] private float speed = 5f;

    public void Switch()
    {
        obstacle.transform.position = Vector3.MoveTowards(transform.position, openPosition, speed * Time.deltaTime);
    }
}
