using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleBox : MonoBehaviour
{
    public GameObject weapon;
    public GameObject answer;
    public GameObject[] options;
    public Canvas canvas;
    AudioSource audioClip;
    public AudioSource correctAnswer;

    int index = 0;
    Coroutine check;
    bool unlocked;

    private void Start()
    {
        audioClip = GetComponent<AudioSource>();
    }

    //Called by button interaction. Increments to the next item in options array
    //Calls the coroutine checkAnswer() to check if the answer is correct
    public void next()
    {
        if (check != null) { StopCoroutine(check); }
        index++;
        foreach (GameObject page in options)
        {
            page.SetActive(false);
        }
        options[Mathf.Abs(index) % options.Length].SetActive(true);
        check = StartCoroutine(checkAnswer());
        audioClip.Play();
        audioClip.pitch = Random.Range(1f, 2f);
    }

    //Called by button interaction. Decrements to the previous item in options array
    //Calls the coroutine checkAnswer() to check if the answer is correct
    public void prev()
    {
        if (check != null) { StopCoroutine(check); }
        index--;
        foreach (GameObject page in options)
        {
            page.SetActive(false);
        }
        options[Mathf.Abs(index) % options.Length].SetActive(true);
        check = StartCoroutine(checkAnswer());
        audioClip.Play();
        audioClip.pitch = Random.Range(1f, 2f);
    }

    //If the answer is not changed for 1 second, coroutine checks to see if the current option is the answer
    //It does not do this if the correct answer has already been chosen once
    IEnumerator checkAnswer() 
    {
        yield return new WaitForSeconds(1);
        if (options[Mathf.Abs(index) % options.Length] == answer && !unlocked)
        {
            GameObject spawnWeapon = Instantiate(weapon, transform.position + (Vector3.up * 5f), Quaternion.identity);
            unlocked = true;
            correctAnswer.Play();
        }
    }
}
