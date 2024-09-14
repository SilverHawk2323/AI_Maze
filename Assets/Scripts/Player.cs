using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraMode currentCameraMode;

    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float gravity;
    public float jumpPower;
    public Transform firstPersonCamera;
    public Transform thirdPersonCamera;
    private CharacterController cc;

    public Vector3 moveDirection;

    public Vector2 input;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //get inputs for this frame
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        //apply those inputs to our horizontal plane
        moveDirection.x = input.x * walkSpeed;
        moveDirection.z = input.y * walkSpeed;

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = sprintSpeed;
        }
        else
        {
            walkSpeed = 10;
        }*/

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection.x = input.x * sprintSpeed;
            moveDirection.z = input.y * sprintSpeed;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            moveDirection.x = input.x * crouchSpeed;
            moveDirection.z = input.y * crouchSpeed;
        }

        //apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //if our character controller detects ground below it
        if (GetComponent<CharacterController>().isGrounded)
        {
            moveDirection.y = Mathf.Clamp(moveDirection.y, -gravity, float.PositiveInfinity);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpPower;
            }
        }
        Move(moveDirection);

        

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.gm.switchCamera();
        }*/
    }
    private void Move(Vector3 movement)
    {
        if (currentCameraMode == CameraMode.ThirdPerson)
        {
            /*movement = thirdPersonCamera.transform.TransformDirection(movement);
            Vector3 facingDirection = new Vector3(movement.x, 0, movement.z);
            transform.forward = facingDirection;*/
            walkSpeed = 0f;
            sprintSpeed = 0f;
            crouchSpeed = 0f;
            jumpPower = 0f;
        }
        else    //if we are NOT in third person
        {
            //match the left-right rotation of the camera
            transform.localEulerAngles = new Vector3(0, firstPersonCamera.localEulerAngles.y, 0);
            walkSpeed = 5f;
            sprintSpeed = 20f;
            crouchSpeed = 0f;
            gravity = 9.81f;
            jumpPower = 10f;
            //take our "global" movement direction, and convert it to a local direction
            movement = transform.TransformDirection(movement);
        }
        cc.Move(movement *Time.deltaTime);
        //set our rigidbody's velocity using the incoming movement value
        //rb.velocity = movement;
    }
    public void SetCamera(CameraMode mode)
    {
        currentCameraMode = mode;
    }

}
