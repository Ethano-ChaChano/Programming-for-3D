using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class userInterface : MonoBehaviour
{
    [SerializeField] private TMP_Text timeUI;
    [SerializeField] private TMP_Text livesUI;
    [SerializeField] private TMP_Text placesUI;    
    
    [SerializeField] private string successText = "You Win! Time: ";
    [SerializeField] private string failText = "Fail - Better Luck Next Time!";

    private float gameTime = 0;
    private bool isFinished = false;

    void Start()
    {
        if (timeUI && livesUI && placesUI) { timeUI.text = "Time: " + gameTime.ToString(); }

        else
        {
            if (timeUI == null) { Debug.Log("UI has no time UI"); }
            if (livesUI == null) { Debug.Log("UI has no lives UI"); }
            if (placesUI == null) { Debug.Log("UI has no places UI"); }
        }
    }

    void Update()
    {
        if (!isFinished)
        {
            gameTime += Time.deltaTime;
            timeUI.text = "Time: " + gameTime.ToString("f2") + " Seconds";
        }
    }

    public void UpdateLives(int numLives)
    {
        livesUI.text = "Lives: " + numLives.ToString();
    }

    public void UpdatePlaces(int numPlaces)
    {
        placesUI.text = "Places: " + numPlaces.ToString();
    }

    public void HasFinished(bool success)
    {
        isFinished = true;
        if (success)
        {
            gameTime += Time.deltaTime;
            timeUI.text = successText + gameTime.ToString("f2") + " Seconds";
        }
        else { timeUI.text = failText; }

    }
}
