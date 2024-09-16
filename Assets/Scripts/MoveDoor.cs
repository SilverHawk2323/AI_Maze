using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public enum DoorStates
    {
        Opened,
        Closed,
        Opening,
        Closing,
        Locked,
    }




    public Vector3 openingDirection = new Vector3(0f, -3f, 0);
    public float speed = 5f;
    public bool unlockDoor = false;
    public DoorStates state = DoorStates.Closed;
    public float waitTime = 5f;

    private float _startOfWait;
    private Vector3 _closedPosition = Vector3.zero;
    private Vector3 _openPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _closedPosition = transform.position;
        _openPosition = transform.position + openingDirection;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case DoorStates.Closed:
                if (waitTime < Time.time - _startOfWait)
                {
                    state = DoorStates.Opening;
                }
                break;
            case DoorStates.Opening:
                transform.position = Vector3.MoveTowards(transform.position, _openPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, _openPosition) < 0.01f)
                {
                    state = DoorStates.Opened;
                    //_startOfWait = Time.time;
                }
                break;
            case DoorStates.Closing:
                transform.position = Vector3.MoveTowards(transform.position, _closedPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, _closedPosition) < 0.01f)
                {

                }
                break;
            case DoorStates.Opened:
                /*if (waitTime < Time.time - _startOfWait )
                {
                    state = DoorStates.Closing;
                }*/
                break;
            case DoorStates.Locked:
                if (unlockDoor)
                {
                    state = DoorStates.Opening;
                }
                break;

            default:
                break;
        }







        
    }
}
