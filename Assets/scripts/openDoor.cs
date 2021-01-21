using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animator anim;
    private bool isInRadius;

    public void Start()
    {
        anim.SetBool("inRange", false);
    }

    private void Update()
    {
        if (isInRadius)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("inRange", !anim.GetBool("inRange"));
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player entered");
            isInRadius = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRadius = false;
    }
}
