using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private ObjectPool spawner;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private bool facingRight;

    private void Start()
    {
        enemy.SetActive(true);
        enemy.transform.position = spawner.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(facingRight = true)
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        else
        {
            transform.position += -1 * transform.right * Time.deltaTime * moveSpeed;
        }
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log("Collision");
        enemy.SetActive(false);
        spawner.Spawn();
    }
}
