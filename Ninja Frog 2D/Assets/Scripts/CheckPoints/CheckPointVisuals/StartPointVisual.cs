using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointVisual : MonoBehaviour
{
    [SerializeField]private Animator animator;
    private const string STARTED = "Started";
    private bool hasStarted=false;
    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInput>())
        {
            if (!hasStarted)
            {
                animator.SetTrigger(STARTED);
            }

            hasStarted = true;
        }
       
    }


}
