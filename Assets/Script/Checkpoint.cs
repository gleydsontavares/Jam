using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public string sceneName; // Nome da cena a ser carregada

    private bool cubo1 = false;
    private bool cubo2 = false;
    private bool cubo3 = false;

    private AudioSource audioSource;
    public AudioClip winAudioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cubo1"))
        {
            cubo1 = true;
            CheckCompletion();
        }
        else if (collision.CompareTag("cubo2"))
        {
            cubo2 = true;
            CheckCompletion();
        }
        else if (collision.CompareTag("cubo3"))
        {
            cubo3 = true;
            CheckCompletion();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("cubo1"))
        {
            cubo1 = false;
        }
        else if (collision.CompareTag("cubo2"))
        {
            cubo2 = false;
        }
        else if (collision.CompareTag("cubo3"))
        {
            cubo3 = false;
        }
    }

    private IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(sceneName);
    }

    private void CheckCompletion()
    {
        if (cubo1 && cubo2 && cubo3)
        {
            audioSource.clip = winAudioClip;
            audioSource.Play();
            StartCoroutine(DelayedLoadScene());
        }
    }
}
