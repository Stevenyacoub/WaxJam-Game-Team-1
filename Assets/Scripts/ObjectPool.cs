using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Container for our White Blood Cells using pooling
public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private int amount;
    private int index = 0; //for counting Spawns
    private List<GameObject> objects = new List<GameObject>();

    private void InitializeObjects()
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject newObject = GameObject.Instantiate(enemyPrefab);
            newObject.SetActive(false);
            objects.Add(newObject);
        }
    }

    public GameObject Spawn()
    {
        GameObject currentSpawn = objects[index];
        currentSpawn.SetActive(true);
        
        index = (index + 1)%objects.Count;

        return currentSpawn;
    }
}
