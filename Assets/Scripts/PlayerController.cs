using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Input Management 
    private float verticalInput;
    private bool jumpInput; 


    //Speed
    public float moveSpeed; 
    public float jumpForce; 
    public float dashForce;
    public bool canMove = true;

    //mechanics 
    public bool openDoor = false;

    //Components and Game Objects
    private Rigidbody rb;
    public GameObject focalPoint;



    // Start is called before the first frame update
    void Start()
    {
        //Get components 
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement(){
        //Get input  
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetKeyDown(KeyCode.Space);

        //Get forward direction of camera using focalPoint
        Vector3 forwardDirection = focalPoint.transform.forward;

        //Move 
        if(canMove){
            //add force if player can move in camera direction 
            rb.AddForce(forwardDirection * verticalInput * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        //Jump 
        if(jumpInput){
            rb.AddExplosionForce(10f, transform.position, 1.0f, 10f, ForceMode.Impulse);
        }
        
    }
    void OnTriggerEnter(Collider other){
        Debug.Log(other.name);

        if(other.CompareTag("Perk")){
            Destroy(other.gameObject);
            openDoor = true; 
            Debug.Log("Congratulations, you have escaped!");
        }
    }

    
}
