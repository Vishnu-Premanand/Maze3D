using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 followOffset;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 threshold;

    private void Start()
    {
        threshold = CalculateThreshold();
        rb = target.GetComponent<Rigidbody2D>();
        
    }
    private void LateUpdate()
    {
        Vector2 follow = target.transform.position;
        float XDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float YDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.right * follow.y);
        Vector3 newPosition = transform.position;
        if (Mathf.Abs(XDifference) > threshold.x)
        {
            newPosition.x = follow.x;
        }
        if (Mathf.Abs(YDifference) > threshold.y)
        {
            newPosition.y = follow.y;
        }

        float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
        transform.position = Vector2.Lerp(transform.position,newPosition, moveSpeed * Time.deltaTime);
    }

    private Vector3 CalculateThreshold()
    {

        Rect aspect = Camera.main.pixelRect;
        Vector3 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
       
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2,1));
    }
}
