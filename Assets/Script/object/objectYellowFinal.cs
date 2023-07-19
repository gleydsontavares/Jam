using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectYellowFinal : MonoBehaviour
{
    public Collider plataformBlueCollider;
    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = true;
        }
    }

    private void Update()
    {
        if (isActivated && Input.GetKeyDown(KeyCode.K))
        {
            plataformBlueCollider.isTrigger = false;
            isActivated = false;
        }
    }
}






