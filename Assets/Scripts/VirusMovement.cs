using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using UnityEngine;

public class VirusMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 0.5f;
    Vector3 mousePosition;
    Rigidbody2D rb;

    Vector2 position = new Vector2(0f, 0f);

    [SerializeField]
    bool isLevelStarted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isLevelStarted)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (isLevelStarted)
        {
            rb.MovePosition(position);
        }
    }

    public void GrantControl()
    {      
        isLevelStarted = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void StopControl()
    {
        isLevelStarted = false;
        Cursor.visible = true;
    }
}