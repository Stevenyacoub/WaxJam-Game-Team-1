using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//Simple behavior that causes the screen to have a shaking effect
//Intended to be used when the player receives damage
public class ScreenShake : MonoBehaviour
{
    [SerializeField] private Transform transform;

    [SerializeField] private float shakeDuration = 0f;
    [SerializeField] private float shakeMagnitude = 0.4f;
    [SerializeField] private float dampingSpeed = 1f;

    Vector3 initialPosition;

    void Awake()
    {
        if(transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if(shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    //Activate a screenshake from another script
    public void TriggerShake()
    {
        shakeDuration = 0.4f;
    }
}
