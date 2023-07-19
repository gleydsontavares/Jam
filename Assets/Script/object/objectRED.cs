using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectRED : MonoBehaviour
{
    public Rigidbody plataformGreen;
    public float actionTime;
    private bool isActionActive = false;
    private bool isPlayerColliding = false;

    private void Update()
    {
        if (isActionActive)
        {
            actionTime -= Time.deltaTime;

            if (actionTime <= 0f)
            {
                StopAction();
            }
        }
    }

    private void StartAction()
    {
        if (!isActionActive)
        {
            isActionActive = true;
            plataformGreen.isKinematic = false;
        }
    }

    private void StopAction()
    {
        if (isActionActive)
        {
            isActionActive = false;
            plataformGreen.isKinematic = true;
            actionTime = 10f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerColliding = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.K) && isPlayerColliding)
        {
            StartAction();
        }
    }
}