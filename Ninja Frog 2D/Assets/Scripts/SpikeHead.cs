using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    private Vector3 currentPos;
    private void Start()
    {
        currentPos = transform.position;
    }
    private void Update()
    {
        transform.position = currentPos + new Vector3(0f, Mathf.Sin(Time.time)*2,0f);
    }
}
