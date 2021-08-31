using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed = 5;
    public float jumpVelocity = 120f;
    private float gravityVelocity = -9.8f;
    private Vector3 move;
    
    private InputMaster controls;
    private InputAction moveAction;
    private InputAction jumpAction;
    
    private float turnSmoothtime = 0.1f;
    private float turnSmoothVelocity;
    public Transform cam;

    private void Awake()
    {
        controls = new InputMaster();
    }

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction = controls.Player.Move;
        moveAction.Enable();

        jumpAction = controls.Player.Jump;
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    private void Update()
    {

        move = new Vector3(moveAction.ReadValue<Vector2>().x * moveSpeed, 0f, moveAction.ReadValue<Vector2>().y * moveSpeed);

        float jump = jumpAction.ReadValue<float>();
        if (cc.isGrounded)
        {
            move.y += jump * jumpVelocity;
            
        } else
        {
            move.y += gravityVelocity;
        }
        
        cc.Move(move * Time.deltaTime);


        //     float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothtime);
        //     transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //
        //     Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //     print("moveDir: " + moveDir);
        //     print("moveDir.normalized: " + moveDir.normalized);
        //     print("moveDir.normalized * velocity: " + moveDir.normalized * velocity);
        //     cc.Move(moveDir.normalized * velocity * Time.deltaTime); 
    }
}
