using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    [HideInInspector] public Vector3 moveDirection;
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;

    public float currentMoveSpeed = 5f;
    public float walkSpeed = 3f, walkBackSpeed = 2f;
    public float runSpeed = 7f, runBackSpeed = 5f;
    public float crouchSpeed = 2f, crouchBackSpeed = 1f;

    private float gravity = -9.8f;
    CharacterController controller;
    Vector3 spherePos;
    Vector3 velocity;
    [HideInInspector] public float hzInput, vInput;

    public MovementBaseState currentState;
    public IdleState idle = new IdleState();
    public WalkState walk = new WalkState();
    public RunState run = new RunState();
    public CrouchState crouch = new CrouchState();

    [HideInInspector] public Animator anime;

    
    void Start()
    {
        anime = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(idle);
    }
    void Update()
    {
        ApplyMovement();
        Gravity();

        currentState.UpdateState(this);

        anime.SetFloat("hzInput", hzInput);
        anime.SetFloat("vInput", vInput);

    }
    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Gravity()
    {
        if (!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    private void ApplyMovement()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        moveDirection = transform.forward * vInput + transform.right * hzInput;

        controller.Move(moveDirection.normalized * Time.deltaTime * currentMoveSpeed);
    }
    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(spherePos, controller.radius - 0.05f);
    // }
}
