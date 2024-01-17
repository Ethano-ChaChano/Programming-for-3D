using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class interactionManager : MonoBehaviour
{
    public Canvas buttonPrompt;
    public Canvas investigationScreen;
    public TMP_Text tmpName;
    public TMP_Text tmpDescription;

    //public float gameplayTime = 600f;
    //public float currentTime = 0f;

    void Start()
    {
        //currentTime = gameplayTime;
    }

    void Update()
    {
        // Update the timer
        //currentTime += Time.deltaTime;

        //// Check if the timer has reached zero
        //if (currentTime >= gameplayTime)
        //{
        //    currentTime = gameplayTime;
        //    Debug.Log("Time's up!"); //kill player with monster
        //}

        // Update UI text
    }
}
