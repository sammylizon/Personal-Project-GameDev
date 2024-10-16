using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Input Management 
    private float horizontalInput; 
    private float verticalInput;
    private bool jumpInput; 
    // private float dashInput;


    //Speed
    public float moveSpeed; 
    public float jumpForce; 
    public float dashForce;
    public bool canMove = true;

    //Components 
    private Rigidbody rb;



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
        horizontalInput = Input.GetAxisRaw("Horizontal"); 
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetKeyDown(KeyCode.Space);

        //Move 

        if(canMove){
            rb.AddForce(horizontalInput * moveSpeed *Time.deltaTime, 0, verticalInput * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        //Jump 
        if(jumpInput){
            rb.AddExplosionForce(10f, transform.position, 1.0f, 10f, ForceMode.Impulse);
        }
        
    }
    public void OnCollisonEnter(Collider other){
        if(other.gameObject.CompareTag("Perk")){
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.tag);
        }
    }

    
}
