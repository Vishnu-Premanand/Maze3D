using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointVisual : MonoBehaviour
{
    [SerializeField] private CheckPointSingle checkPointSingle;
    private Animator animator;
    private bool CheckPointReached;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        checkPointSingle.OncheckPointReached += CheckPointSingle_OncheckPointReached;
        CheckPointReached = false;
    }

    private void CheckPointSingle_OncheckPointReached(object sender, System.EventArgs e)
    {
        CheckPointReached = true;
    }
    private void Update()
    {
        animator.SetBool("CheckPointReached ", CheckPointReached);
    }
}
