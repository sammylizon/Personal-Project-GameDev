using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + startPos;
        // transform.rotation = player.transform.rotation;
        
    }

    
}
