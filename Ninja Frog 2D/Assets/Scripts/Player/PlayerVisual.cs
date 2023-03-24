using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string _IS_RUNNING = "IsRunning";
    private const string _IS_JUMPING = "IsJumping";
    private const string _IS_Falling = "IsFalling";
    private const string _IS_DEAD = "IsDead";
    [SerializeField] private PlayerInput playerInput;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        playerInput.startedRunning += startedRunningAnimation;
        playerInput.IsJumping += PlayerInput_IsJumping;
        playerInput.IsFalling += PlayerInput_IsFalling;
        playerInput.onDeath += PlayerInput_onDeath;
    }

    private void PlayerInput_onDeath(object sender, System.EventArgs e)
    {
        animator.SetTrigger(_IS_DEAD);
    }

    private void PlayerInput_IsFalling(object sender, System.EventArgs e)
    {
        if (playerInput.GroundCheck())
        {
            return;
        }
        if (!playerInput.GroundCheck())
        {
            animator.SetTrigger(_IS_Falling);
        }
    }

    private void PlayerInput_IsJumping(object sender, System.EventArgs e)
    {
        animator.SetTrigger(_IS_JUMPING);
    }

    private void startedRunningAnimation(object sender, PlayerInput.StartedRunning e)
    {
        if (e.horiMove < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool(_IS_RUNNING, true);
        }
        if (e.horiMove > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool(_IS_RUNNING, true);
        }
        if(e.horiMove==0)
        {
            animator.SetBool(_IS_RUNNING, false);
        }
    }
}
