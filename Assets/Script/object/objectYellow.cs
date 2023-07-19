using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectYellow : MonoBehaviour
{
    public Collider plataformPurple;
    public Collider plataformPurple2;
    public Collider plataformPurple3;
    public float actionTime;
    public bool isActionActive = false;
    private float actionTimer = 0f;
    private bool keyPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (isActionActive)
        {
            actionTimer += Time.deltaTime;

            if (actionTimer >= actionTime)
            {
                plataformPurple.isTrigger = true;
                plataformPurple2.isTrigger = true;
                plataformPurple3.isTrigger = true;
                isActionActive = false;
            }
        }
        else
        {
            if (keyPressed && Input.GetKeyDown(KeyCode.K))
            {
                keyPressed = false;
                isActionActive = true;
                actionTimer = 0f;

                plataformPurple.isTrigger = false;
                plataformPurple2.isTrigger = false;
                plataformPurple3.isTrigger = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keyPressed = true;
        }
    }
}