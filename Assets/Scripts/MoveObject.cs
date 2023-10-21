using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5;

    [SerializeField]
    private Vector3 movementDistance;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position + movementDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.SqrMagnitude(transform.position - targetPosition) <= 0.001f)
        {
            transform.position = targetPosition;
            targetPosition = targetPosition - (movementDistance * (movementSpeed > 0 ? 1 : -1));
            movementSpeed = -movementSpeed;
        }
        else
        {
            //little hack cause MoveTowards will adjust direction for us relative to timescale, but we also want to track our direction interally
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Mathf.Abs(movementSpeed));
        }
    }
}
