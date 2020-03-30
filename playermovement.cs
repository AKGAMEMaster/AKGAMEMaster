using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed=12f;
    Vector3 velocity;
    public float gravity=-100.81f;
    public Transform groundcheck;
    public float groundDistance=0.4f;
    public LayerMask groundmask;
    bool isGrounded;
    public float runspeed=1f;
    public float jumpheight=3f;
    // Update is called once per frame
    void Update()
    {
        isGrounded=Physics.CheckSphere(groundcheck.position,groundDistance,groundmask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y=-2f;
        }
        
        float x=Input.GetAxis("Horizontal");
        float y=Input.GetAxis("Vertical");
        float run=Input.GetAxis("RUN");
        Vector3 move=transform.right*x+transform.forward*y;
       
        controller.Move(move*speed*Time.deltaTime);
        velocity.y+=gravity*2f*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y=Mathf.Sqrt(jumpheight*-2*gravity);
            runspeed=0f;
        }
        else
        {
            runspeed=10f;
            isGrounded=true;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move*runspeed*Time.deltaTime);
        }
        



    }
}
