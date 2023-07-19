using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectGreen : MonoBehaviour
{
    public Rigidbody plataformRed;
    public float actionTime;
    public Animator characterAnimator; // Referência ao Animator do personagem.
    private bool isActionActive = false;
    private bool isPlayerColliding = false;

    private Coroutine interactionCoroutine; // Referência à corrotina de interação.

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

            // Inicie a corrotina de interação.
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

            // Pare a corrotina de interação, caso esteja em execução.
            if (interactionCoroutine != null)
            {
                StopCoroutine(interactionCoroutine);
                interactionCoroutine = null;
            }

            // Ao finalizar a ação, retorne à animação "idle".
            characterAnimator.SetBool("Idle_animation1", false);
        }
    }

    private IEnumerator InteractCoroutine()
    {
        // Ative a animação de interação no personagem.
        characterAnimator.SetBool("Tinta_anim", true);

        // Aguarde a duração da ação.
        yield return new WaitForSeconds(actionTime);

        // Termine a ação.
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