using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private float speed;
    private int waypointIndex = 0;
    private void Update()
    {
        if (Vector2.Distance(wayPoints[waypointIndex].transform.position, transform.position) < .1f)
        {
            waypointIndex++;
            if (waypointIndex > wayPoints.Length-1)
            {
                waypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, Time.deltaTime * speed);
        RotateSaw();
    }
    private void RotateSaw()
    {
        if(Vector2.Distance(wayPoints[0].transform.position, transform.position) < .1f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Vector2.Distance(wayPoints[1].transform.position, transform.position) < .1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
