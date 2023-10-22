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
    [SerializeField] private ScreenShake shaker;
    Rigidbody2D rb;
    private AudioSource _crashSound;

    Vector3 position = Vector3.zero;

    [SerializeField]
    bool isLevelStarted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _crashSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isLevelStarted)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (isLevelStarted)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, position - transform.position, out hit, 3.0f))
            {
                rb.MovePosition(hit.point);
            }
            else
            {
                rb.MovePosition(position);
            }
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
    public void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log("Player Collision");
        _crashSound.Play();
        shaker.TriggerShake(0.2f);
    }
}