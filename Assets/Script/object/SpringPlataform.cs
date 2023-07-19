using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlataform : MonoBehaviour
{
    public float springForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonController player = other.GetComponent<ThirdPersonController>();
            if (player != null)
            {
                player.ApplySpringForce(springForce);
            }
        }
    }
}
