using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    //how fast should the camera move around at
    public float sensitivity = 1f;

    //how rotated is the camera currently 
    private float currentRotationHorizontal;
    private float currentRotationVertical;

    // where should the camera be positioned
    public Transform playerTransform;
    public float playerEyeLevel = 0.5f; // <-- set a starting default value

    //How far is the camera allowed to rotate up and down
    public float verticalRotationMin;
    public float verticalRotationMax;


    // Start is called before the first frame update
    void Start()
    {
        currentRotationHorizontal = transform.localEulerAngles.y;
        currentRotationVertical = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentRotationHorizontal += Input.GetAxis("Mouse X") * sensitivity;
        //Unity = +ve Y is up. Screen space = -ve Y is up.
        currentRotationVertical -= Input.GetAxis("Mouse Y") * sensitivity;

        //Value we want to clamp, Smallest number first, highest number last
        currentRotationVertical = Mathf.Clamp(currentRotationVertical, verticalRotationMin, verticalRotationMax);

        //apply the rotation to the camera object
        transform.localEulerAngles = new Vector3(currentRotationVertical, currentRotationHorizontal, 0);

        //snap the camera to the player's eye level + position
        transform.position = playerTransform.position + Vector3.up * playerEyeLevel;
    }
}