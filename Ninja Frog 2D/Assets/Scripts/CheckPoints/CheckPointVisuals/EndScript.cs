using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    private Collider2D cupCollider;
    private Animator animator;
    private bool hasEnded=false;
    private void Awake()
    {
        cupCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInput playerInput = collision.gameObject.GetComponent<PlayerInput>();
        Animator playerAnim = collision.gameObject.GetComponentInChildren<Animator>();
        
        if (collision.gameObject.GetComponent<PlayerInput>())
        {
            hasEnded = true;
            if (hasEnded)
            {
                animator.SetTrigger("reached");
                Time.timeScale = 0;
                
            }
        }
        
    }
}
