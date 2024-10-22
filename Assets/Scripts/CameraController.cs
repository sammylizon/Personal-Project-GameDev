using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{

    private GameObject player;
    public float rotationSpeed = 10f; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //set focalPoint to follow player 
        transform.position = player.transform.position;

        //Rotate the camera on the Y axis based on horizontal input
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed);
        // transform.rotation = player.transform.rotation;
        
    }

    
}
