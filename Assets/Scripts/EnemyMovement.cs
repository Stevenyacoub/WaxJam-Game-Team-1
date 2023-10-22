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

    private void Start()
    {
        enemy.transform.position = spawner.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * moveSpeed;
        spawner.Spawn();
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        enemy.SetActive(false);
        spawner.Spawn();
    }
}
