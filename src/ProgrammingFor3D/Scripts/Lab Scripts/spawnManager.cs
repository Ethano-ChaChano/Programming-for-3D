using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    [SerializeField] private GameObject thing;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int maxThings = 10;

    private int numThings = 0;
    private bool canSpawn = false;

    void Start()
    {
        if (thing && spawnPoint) { canSpawn = true; }

        else
        {
            if (thing == null) { Debug.Log("SpawnController has no GameObject"); }
            if (spawnPoint == null) { Debug.Log("SpawnController has no spawnpoint"); }
        }
    }

    public bool Spawn()
    {
        if (numThings < maxThings)
        {
            GameObject clone = Instantiate(thing, spawnPoint.position, Quaternion.identity) as GameObject;
            clone.SetActive(true);
            numThings++;
            return true;
        }

        else
        {
            canSpawn = false;
            return false;
        }
    }

    public bool CanSpawn { get { return canSpawn; } }
}