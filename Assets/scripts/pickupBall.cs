using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBall : MonoBehaviour
{
    public Transform spawnPoint;
    public float power = 200;
    
    private Transform player;
    private Rigidbody rb;
    private bool moveWithCam = false;
    private float powerBefore = 0;
    private Vector3 pushDir;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPoint = GameObject.FindWithTag("spawnPoint").transform;
        player = GameObject.FindWithTag("Player").transform;
        powerBefore = power;
    }

    public void Update()
    {
        if (moveWithCam)
        {
            transform.position = spawnPoint.position;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Debug.Log("grounded");
            if (power >= 0)
            {
                power -= Time.deltaTime;
                rb.AddForce(pushDir.normalized / power);
            }
        }
    }

    public void OnCollisionExit(Collision other)
    {
        power = powerBefore;
    }

    public void OnMouseDown()
    {
        // hold it
        // pick up the ball
        Debug.Log("pick up");
        rb.useGravity = false;
        moveWithCam = true;
    }

    public void OnMouseUp()
    {
        // throw the ball
        StartCoroutine(throwBall());
        Debug.Log("dropped");
    }

    IEnumerator throwBall()
    {
        rb.useGravity = true;
        rb.AddForce(player.transform.forward * power);
        moveWithCam = false;
        yield return new WaitForSeconds(5);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    
}