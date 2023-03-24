using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackCheckPoints : MonoBehaviour
{
    [SerializeField] private Transform[] checkPoints;
    [SerializeField] private PlayerInput playerInput;
    private Transform currentCheckPointTransform;
    private void Start()
    {
        
        foreach (Transform checkPointsingleTransform in checkPoints)
        {
            CheckPointSingle checkPointSingle = checkPointsingleTransform.GetComponent<CheckPointSingle>();
            checkPointSingle.SetCheckPoint(this);
        }

        playerInput.onDeath += PlayerInput_onDeath;
        
    }
    private void Update()
    {
        
    }

    private void PlayerInput_onDeath(object sender, System.EventArgs e)
    {
        playerInput.gameObject.SetActive(false);
        Invoke("RespawnPlayer", .5f);
        playerInput.gameObject.SetActive(true);
    }
    private void RespawnPlayer()
    {
        playerInput.gameObject.transform.position = currentCheckPointTransform.position;
    }

    public void PassedCheckPoint(CheckPointSingle checkPointSingle)
    {
        currentCheckPointTransform = checkPointSingle.transform;
    }
}
