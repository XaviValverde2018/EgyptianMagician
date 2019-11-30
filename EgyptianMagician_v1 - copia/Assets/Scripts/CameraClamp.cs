using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;
    private float minXBoundariesCamera=-4.9f, maxXBoundariesCamera=5.97f, minZBoundariesCamera=-28.0f, maxZBoundariesCamera=5.48f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, minXBoundariesCamera, maxXBoundariesCamera),
            transform.position.y,
            Mathf.Clamp(targetToFollow.position.z, minZBoundariesCamera, maxZBoundariesCamera));
    }
}
