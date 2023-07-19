using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectBlue : MonoBehaviour
{
    public Collider plataformOrange;
    public float actionTime;
    public bool isActionActive = false;
    private float actionTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActionActive)
        {

            actionTimer += Time.deltaTime;


            if (actionTimer >= actionTime)
            {

                plataformOrange.isTrigger = true;
                isActionActive = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            isActionActive = true;
            actionTimer = 0f;

            plataformOrange.isTrigger = false;

        }
    }
}
