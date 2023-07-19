using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectLeverBlue : MonoBehaviour
{
    public plataformFinal movingPlatform;
    public CharacterController playerCharacterController;
    public KeyCode interactionKey = KeyCode.K;

    private bool isActivated = false;

    private void Update()
    {
        if (isActivated)
        {
            return;
        }

        if (Input.GetKeyDown(interactionKey) && IsPlayerInRange())
        {
            movingPlatform.StartMoving();
            isActivated = true;
        }
    }

    private bool IsPlayerInRange()
    {
        
        Vector3 playerPosition = playerCharacterController.transform.position;
        Vector3 leverPosition = transform.position;
        float interactionRadius = 2f;

        if (Vector3.Distance(playerPosition, leverPosition) <= interactionRadius)
        {
            return true;
        }

        return false;
    }
}