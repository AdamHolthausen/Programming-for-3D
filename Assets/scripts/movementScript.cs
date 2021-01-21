using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15f;// variable for players speed of movement 
    public bool spawned = false;
    public GameObject ball;
    public Transform spawnPoint;
    public Animator anim;
    private GameObject spawnedObj;
    private Vector3 velocity;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;


    private void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move* speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            if (!spawned)
            {
                spawned = true;
                spawnedObj = Instantiate(ball, spawnPoint.position, transform.rotation);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetAxis("Horizontal") > 0.2 || Input.GetAxis("Vertical") > 0.2)
        {
            anim.SetBool("isWalking", true);
        }
        else 
        {
            anim.SetBool("isWalking", false);
        }
    }
}
