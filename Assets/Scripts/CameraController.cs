using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraMode
{
    FirstPerson,
    ThirdPerson
}


public class CameraController : MonoBehaviour
{
    private FirstPersonCamera firstPersonCamera;
    private TopDownCamera topDownCamera;
    private Player player;
    //SerialiszeField allows us to view and edit private variables in the unity inspector. Serialize = conver to readable data. Field = the variable.
    [SerializeField] private CameraMode currentCameraMode;

    // Start is called before the first frame update
    void Start()
    {
        //lock the cursor to the centre of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //make the cursor invisible
        Cursor.visible = false;

        //FindObjectofType will look for the first instance of the type provided in the scene.
        //It does NOT look in inactive game objects by default.We can pass "True" to include inactive objects.
        firstPersonCamera = FindObjectOfType<FirstPersonCamera>(true);
        topDownCamera = FindObjectOfType<TopDownCamera>(true);
        player = FindObjectOfType<Player>(true);

        SetCameraMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.pauseGame)
        {
            return;
        }
        //KeyCode is an enumerator which contains all the keyboard keys
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleCameras();
        }
    }

    //swap from the current camera control to the other camera control
    private void ToggleCameras()
    {
        if (currentCameraMode == CameraMode.FirstPerson)
        {
            currentCameraMode = CameraMode.ThirdPerson;
        }
        else
        {
            currentCameraMode = CameraMode.FirstPerson;
        }

        SetCameraMode();
    }

    //apply the camera mode to the game
    private void SetCameraMode()
    {
        if (currentCameraMode == CameraMode.FirstPerson)
        {
            firstPersonCamera.gameObject.SetActive(true);
            topDownCamera.gameObject.SetActive(false);
        }
        else
        {
            firstPersonCamera.gameObject.SetActive(false);
            topDownCamera.gameObject.SetActive(true);
        }
        player.SetCamera(currentCameraMode);
    }
}
