
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EntryPoints;

public class gameController : MonoBehaviour
{
    [SerializeField] private int maxFalls = 3;
    [SerializeField] private int maxPlaces = 5;
    public bool hasFallen;


    private GameObject player;
    private spawnController spawnController;
    private userInterface userInterface;

    private Vector3 startPosition;

    private int numFalls = 0;
    private int numPlaces = 0;

    private bool doSpawn = true;

    private EntryPoints.place[] places;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnController = GetComponentInChildren<spawnController>();
        userInterface = GetComponentInChildren<userInterface>();

        if (player != null)
        {

            if (spawnController != null)
            {
                if (userInterface != null)
                {
                    startPosition = player.transform.position;
                    places = new EntryPoints.place[maxPlaces];
                    userInterface.UpdateLives(maxFalls);
                    userInterface.UpdatePlaces(maxPlaces);

                }

                else { Debug.Log("No UI"); }
            }
            else { Debug.Log("No spawn controller"); }
        }

        else { Debug.Log("No player tagged"); }
    }

    void FixedUpdate()
    {
        if (doSpawn)
        {
            if (spawnController.CanSpawn) { doSpawn = spawnController.Spawn(); }
            else { Debug.Log("Can't Spawn"); }
        }
        if (hasFallen) { checkFallen(); }
    }

    public void checkFallen()
    {
        numFalls++;
        if (numFalls < maxFalls)
        {
            userInterface.UpdateLives(maxFalls - numFalls);
            player.transform.position = startPosition;
        }
        else
        {
            userInterface.UpdateLives(0);
            userInterface.HasFinished(false);

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
        hasFallen = false;
    }

    public void HasEntered(EntryPoints.place location)
    {
        // Debug.Log("Game Controller Entry place " + place.ToString());
        if (!places.Contains(location))
        {
            // Debug.Log("New Entry place " + place.ToString());
            places[numPlaces] = location;

            numPlaces++;
            if (numPlaces == maxPlaces)
            {
                // Debug.Log("Game complete!");
                userInterface.UpdatePlaces(0);
                userInterface.HasFinished(true);
            }

            else { userInterface.UpdatePlaces(maxPlaces - numPlaces); }
        }
    }
}
