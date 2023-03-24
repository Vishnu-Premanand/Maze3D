using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Range(0,10)]
    [SerializeField] private float parallaxFactor;
   
    private float length, startPos;
    private GameObject cam;
    
    private void Start()
    {
        cam = Camera.main.gameObject;
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update()
    {
        float temp = cam.transform.position.x * (1f - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;
        Vector3 newPosition = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        transform.position = Vector3.Slerp(transform.position, newPosition, .5f);

        if (temp > startPos + (length / 2))
        {
            startPos += length;
        }
        else if (temp < startPos - (length / 2))
        {
            startPos -= length;
        }
        
        
    }
}
