using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerControls playerControls;


    ////////////////VISIBLE IN EDITOR//////////////////
    public float mouseSensitivityX = 8f;
    public float mouseSensitivityY = 0.5f;
    public float verticalClamp = 85f;
    public float thrust;



    //SETUP
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    //MOUSE LOOK
    public Vector2 GetPlayerLook()
    {
        return new Vector2((float)playerControls.Player.MouseX.ReadValue<float>(), (float)playerControls.Player.MouseY.ReadValue<float>());
    }

    

    /*
    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
    */


    //MOVEMENT
    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetZeroGMovement()
    {
        return playerControls.Player.ZeroGMovement.ReadValue<Vector2>();
    }

    public float GetZeroGUpDown()
    {
        return playerControls.Player.ZeroGUpDown.ReadValue<float>();
    }

    
    public float GetZeroGRoll()
    {
        return playerControls.Player.ZeroGRoll.ReadValue<float>();
    }
    

    //GRAVITY
    public bool GetGravity()
    {
        if(playerControls.Player.GravitySwitch.ReadValue<float>() >= 0.5f)
        {
            return true;
        }
        else return false;
    }

    public bool GetAlignToTarget()
    {
        if(playerControls.Player.AlignToTarget.ReadValue<float>() >= 0.5f)
        {
            return true;
        }
        else return false;
    }
}
