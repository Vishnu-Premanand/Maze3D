using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSingle : MonoBehaviour
{

    public event EventHandler OncheckPointReached;
    
    private TrackCheckPoints trackCheckPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerInput>(out PlayerInput playerInput))
        {
            trackCheckPoints.PassedCheckPoint(this);
            OncheckPointReached?.Invoke(this, EventArgs.Empty);
        }
    }

    public void SetCheckPoint(TrackCheckPoints trackCheckPoints)
    {
        this.trackCheckPoints = trackCheckPoints;
    }
}
