using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectBlueFinal : MonoBehaviour
{
    public Collider plataformYellow;
    public Collider plataformYellow2;
    public Collider plataformYellow3;
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
                plataformYellow.isTrigger = true;
                plataformYellow2.isTrigger = true;
                plataformYellow3.isTrigger = true;
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

                plataformYellow.isTrigger = false;
                plataformYellow2.isTrigger = false;
                plataformYellow3.isTrigger = false;
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
