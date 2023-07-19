using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformFinal : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private bool isMoving = false;
    private bool movingToA = false;

    public void StartMoving()
    {
        if (isMoving)
        {
            return;
        }

        transform.position = pointA.position;
        movingToA = false;
        isMoving = true;
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }

        if (movingToA)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }

        if (transform.position == pointA.position)
        {
            movingToA = false;
        }
        else if (transform.position == pointB.position)
        {
            movingToA = true;
        }
    }
}
