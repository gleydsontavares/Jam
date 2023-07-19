using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectGreen : MonoBehaviour
{
    public Rigidbody plataformRed;
    public float actionTime;
    public Animator characterAnimator; // Refer�ncia ao Animator do personagem.
    private bool isActionActive = false;
    private bool isPlayerColliding = false;

    private Coroutine interactionCoroutine; // Refer�ncia � corrotina de intera��o.

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
            plataformRed.isKinematic = false;

            // Inicie a corrotina de intera��o.
            if (interactionCoroutine == null)
            {
                interactionCoroutine = StartCoroutine(InteractCoroutine());
            }
        }
    }

    private void StopAction()
    {
        if (isActionActive)
        {
            isActionActive = false;
            plataformRed.isKinematic = true;
            actionTime = 10f;

            // Pare a corrotina de intera��o, caso esteja em execu��o.
            if (interactionCoroutine != null)
            {
                StopCoroutine(interactionCoroutine);
                interactionCoroutine = null;
            }

            // Ao finalizar a a��o, retorne � anima��o "idle".
            characterAnimator.SetBool("Idle_animation1", false);
        }
    }

    private IEnumerator InteractCoroutine()
    {
        // Ative a anima��o de intera��o no personagem.
        characterAnimator.SetBool("Tinta_anim", true);

        // Aguarde a dura��o da a��o.
        yield return new WaitForSeconds(actionTime);

        // Termine a a��o.
        StopAction();
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
        if (other.CompareTag("Player") && isPlayerColliding)
        {
            if (Input.GetKeyUp(KeyCode.K))
            {
                StartAction();
            }
        }
    }
}