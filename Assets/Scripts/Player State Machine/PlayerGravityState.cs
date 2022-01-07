using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGravityState : PlayerBaseState
{
    ///////////////COMMON//////////////////
    private GameObject player;
    private InputManager inputManager;
    private UIHelper UIHelper;


    ///////////MOVEMENT CONTROLS///////////
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Camera playerCamera;
    private float playerSpeed = 6f;
    private float gravityValue = -9.81f * 2;


    ///////////MOUSE LOOK CONTROLS///////////
    float mouseSensitivityX;
    float mouseSensitivityY;
    Vector2 mousePosition;
    float verticalClamp;
    float xRotation = 0;



    public override void EnterState(PlayerStateManager _player)
    {
        Debug.Log("GRAVITY ON");

        ///////////////COMMON//////////////////
        player = GameObject.FindGameObjectWithTag("Player");
        inputManager = InputManager.Instance;

        //////////////////UI///////////////////
        UIHelper = GameObject.FindWithTag("UI Helper").GetComponent<UIHelper>();


        ///////////MOVEMENT CONTROLS///////////
        controller = player.transform.GetComponent<CharacterController>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();


        ///////////MOUSE LOOK CONTROLS///////////
        mouseSensitivityX = inputManager.mouseSensitivityX;
        mouseSensitivityY = inputManager.mouseSensitivityY * 0.01f;
        verticalClamp = inputManager.verticalClamp;

        ////////////////SETUP//////////////////
        UIHelper.gravityOnImage.color = Color.green;
        UIHelper.gravityOffImage.color = Color.clear;
    }

    public override void UpdateState(PlayerStateManager _player)
    {
        
        ///////////MOVEMENT CONTROLS///////////
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        move = playerCamera.transform.forward * move.z + playerCamera.transform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);



        ///////////MOUSE LOOK CONTROLS///////////
        mousePosition = inputManager.GetPlayerLook();

        player.transform.Rotate(Vector3.up, mousePosition.x * mouseSensitivityX * Time.deltaTime);

        xRotation -= mousePosition.y * mouseSensitivityY;
        xRotation = Mathf.Clamp(xRotation, -verticalClamp, verticalClamp);
        Vector3 targetRotation = playerCamera.transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.transform.eulerAngles = targetRotation;

        

        ///////////GRAVITY SWITCH////////////
        if (inputManager.GetGravity())
        {
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(() => _player.SwitchState(_player.zeroGravityState));
            seq.AppendCallback(() => player.GetComponent<CharacterController>().enabled = false);
            Debug.Log("GRAVITY OFF");
        }
        
    }

    ///////////TRIGGER////////////
    public override void OnTriggerEnter(PlayerStateManager _player, Collider _collider)
    {

    }


    ///////////LOCAL FUNCTIONS////////////
    public void MouseLook()
    {

    }
}
