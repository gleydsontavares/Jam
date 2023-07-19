using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPurple : MonoBehaviour
{
    public GameObject door;
    public float actionTime;
    public bool isActionActive = false;
    private float actionTimer = 0f;
    public float rotationSpeed = 30f;
    private bool isRotating = false;

    public AudioClip rotationAudioClip;
    private AudioSource audioSource;

    private bool isPlayerColliding = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPlayerColliding && Input.GetKeyDown(KeyCode.K))
        {
            StartRotation();
        }

        if (isRotating)
        {
            door.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            actionTimer += Time.deltaTime;

            if (actionTimer >= actionTime)
            {
                isActionActive = false;
                isRotating = false;

                audioSource.Stop();
            }
        }
    }

    private void StartRotation()
    {
        if (!isRotating)
        {
            isRotating = true;
            isActionActive = true;
            actionTimer = 0f;

            audioSource.clip = rotationAudioClip;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = false;
        }
    }
}