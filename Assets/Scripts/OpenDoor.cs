using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public bool open;
    private float elapsedTime;
    public float moveDuration;
    public Transform pointA;
    public Transform pointB;

    // Start is called before the first frame update
    void Start()
    {
        // open = GetComponent<PlayerController>().openDoor;
        
    }

    // Update is called once per frame
    void Update()
    {
    
        open = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().openDoor;

        if(open){
            Debug.Log("Open The Bloody Door Mate!");
            OpenSesame();
        }
    }

    void OpenSesame(){

        //Code to open the door smoothly by moving from POINTA - POINTB

        //If the time that has passed is less than the time allowed for move then...
        if(elapsedTime < moveDuration){
            //..First add to the elapsed time, the time that has passed since last frame 
            elapsedTime += Time.deltaTime;

            //normalise the time between 0 and 1, then store that for LERP 
            float t = elapsedTime / moveDuration;

            // Create smooth transition using LERP 
            transform.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, t);

        }
    }
}
