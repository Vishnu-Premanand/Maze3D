using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event EventHandler<StartedRunning> startedRunning;
    public event EventHandler IsJumping;
    public event EventHandler IsFalling;
    public event EventHandler onDeath;
    public bool isFalling;
    public float horiMove;

    public class StartedRunning : EventArgs
    {
        public float horiMove;
    }


   
    private const string _TRAP = "Trap";
    private Collider2D col;
    private Rigidbody2D playerRb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float fallMultiplier=2.5f;
    
    private PlayerAction playerActions;
    private void Awake()
    {
        playerActions = new PlayerAction();
        playerActions.Enable();
        playerRb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

    }
    private void Update()
    {
        
        HorizontalMovement();
        playerActions.Player.Jump.performed += Jump_performed;
        MaintainGravity();
        GroundCheck();
        
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (GroundCheck())
        {
            playerRb.AddForce(new Vector2(playerRb.velocity.x, jumpForce), ForceMode2D.Impulse);
            IsJumping?.Invoke(this, EventArgs.Empty);
           
           
        }
    }

    private void HorizontalMovement()
    {
        horiMove = playerActions.Player.Movement.ReadValue<float>();

        transform.Translate(new Vector3(moveSpeed * horiMove * Time.deltaTime, 0f, 0f));
        startedRunning?.Invoke(this, new StartedRunning
        {
            horiMove = horiMove
        }) ;
    }
    public bool GroundCheck()
    {
        float distance = 2f;
        return  Physics2D.Raycast(transform.position, Vector2.down, distance, layerMask);
        
    }
    private void MaintainGravity()
    {
        if (playerRb.velocity.y <= 0)
        {
            playerRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            IsFalling?.Invoke(this, EventArgs.Empty);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _TRAP)
        {
            onDeath?.Invoke(this, EventArgs.Empty);
        }
    }

}
