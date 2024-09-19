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
    [SerializeField] private Transform checkpoint;
    private CharacterController cc;
    public AILogic friend;
    public bool firstPerson;
    public GameObject pauseMenu;

    public Vector3 moveDirection;

    public Vector2 input;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        firstPerson = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            Respawn();
        }

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

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale > 0f)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                GameManager.gm.pauseGame = true;
            }
            else
            {
                Cursor.lockState= CursorLockMode.Locked;
                Cursor.visible = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                GameManager.gm.pauseGame = false;
            }
            

            
        }

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
            walkSpeed = 0f;
            sprintSpeed = 0f;
            crouchSpeed = 0f;
            jumpPower = 0f;
            firstPerson = false;
            friend.FollowPlayer();
        }
        else    //if we are NOT in the top down camera
        {
            //match the left-right rotation of the camera
            transform.localEulerAngles = new Vector3(0, firstPersonCamera.localEulerAngles.y, 0);
            walkSpeed = 5f;
            sprintSpeed = 20f;
            crouchSpeed = 3f;
            gravity = 9.81f;
            jumpPower = 5f;
            firstPerson = true;
            //take our "global" movement direction, and convert it to a local direction
            movement = transform.TransformDirection(movement);
        }
        cc.Move(movement *Time.deltaTime);
    }
    public void SetCamera(CameraMode mode)
    {
        currentCameraMode = mode;
    }

    public CameraMode GetCameraMode()
    {
        return currentCameraMode;
    }

    public void Win()
    {
        walkSpeed = 0f;
        sprintSpeed = 0f;
        crouchSpeed = 0f;
        jumpPower = 0f;
    }

    public void Respawn()
    {
        //instead of destroying the player the game will just move the player to a checkpoint which is an empty game object.
        transform.position = checkpoint.transform.position;
    }
}
