using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerZeroGravityState : PlayerBaseState
{
    ///////////////COMMON//////////////////
    private GameObject player;
    private InputManager inputManager;
    private UIHelper UIHelper;

    ///////////MOVEMENT CONTROLS///////////
    private Rigidbody rb;
    private Camera playerCamera;
    private Transform playerCameraTransform;
    private float thrust = 2f;


    ///////////MOUSE LOOK CONTROLS///////////
    float mouseSensitivityX;
    float mouseSensitivityY;
    Vector2 mousePosition;
    float verticalClamp;
    float xRotation = 0;

    public override void EnterState(PlayerStateManager _player)
    {
        Debug.Log("GRAVITY OFF");

        ///////////////COMMON//////////////////
        player = GameObject.FindGameObjectWithTag("Player");
        inputManager = InputManager.Instance;

        //////////////////UI///////////////////
        UIHelper = GameObject.FindWithTag("UI Helper").GetComponent<UIHelper>();

        ///////////MOVEMENT CONTROLS///////////
        rb = player.gameObject.GetComponent<Rigidbody>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
        playerCameraTransform = playerCamera.transform;

        ///////////MOUSE LOOK CONTROLS///////////
        mouseSensitivityX = inputManager.mouseSensitivityX;
        mouseSensitivityY = inputManager.mouseSensitivityY;
        verticalClamp = inputManager.verticalClamp;

        ////////////////SETUP//////////////////
        rb.AddForce(-player.transform.up * 9.81f, ForceMode.Impulse);
        UIHelper.gravityOnImage.color = Color.clear;
        UIHelper.gravityOffImage.color = Color.red;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        ///////////MOVEMENT CONTROLS///////////
        Vector2 movement = inputManager.GetZeroGMovement();
        float forwardThrust = movement.y * thrust;
        float lateralThrust = movement.x * thrust;

        float verticalThrust = inputManager.GetZeroGUpDown();

        float roll = inputManager.GetZeroGRoll();

        playerCameraTransform = playerCamera.transform;

        rb.AddForce(playerCameraTransform.forward * forwardThrust , ForceMode.Acceleration);
        rb.AddForce(playerCameraTransform.right * lateralThrust, ForceMode.Acceleration);
        rb.AddForce(playerCameraTransform.up * verticalThrust , ForceMode.Acceleration);
        rb.AddTorque(playerCameraTransform.forward * roll , ForceMode.Acceleration);


        ///////////MOUSE LOOK CONTROLS///////////
        mousePosition = inputManager.GetPlayerLook();

        Vector3 playerUp = Vector3.up;
        Vector3 playerRight = Vector3.right;

        player.transform.Rotate(playerUp, mousePosition.x * mouseSensitivityX * Time.deltaTime);
        player.transform.Rotate(playerRight, -mousePosition.y * mouseSensitivityY * Time.deltaTime);

        /*
        xRotation -= mousePosition.y * mouseSensitivityY;
        xRotation = Mathf.Clamp(xRotation, -verticalClamp, verticalClamp);
        Vector3 targetRotation = playerCameraTransform.eulerAngles;
        targetRotation.x = xRotation;
        playerCameraTransform.eulerAngles = targetRotation;
        */



        ///////////GRAVITY SWITCH////////////
        if (inputManager.GetGravity())
        {
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(() => _player.SwitchState(_player.gravityState));
            seq.AppendCallback(() => player.GetComponent<CharacterController>().enabled = true);
            Debug.Log("GRAVITY ON");
        }
        
        
    }

    public override void OnTriggerEnter(PlayerStateManager _player, Collider _collider)
    {

    }
}
