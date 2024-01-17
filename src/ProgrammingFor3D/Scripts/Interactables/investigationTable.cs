using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class investigationTable : MonoBehaviour
{
    public GameObject[] pages;
    AudioSource audioClip;
    int index = 0;

    private void Start()
    {
        audioClip = GetComponent<AudioSource>();
    }

    //Called by button interaction. Increments to the next item in pages array
    public void nextPage() 
    {
        index++;
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }
        pages[Mathf.Abs(index) % pages.Length].SetActive(true);
        audioClip.Play();
        audioClip.pitch = Random.Range(1f, 2f);
    }

    //Called by button interaction. Decrements to the previous item in pages array
    public void prevPage()
    {
        index--;
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }
        pages[Mathf.Abs(index) % pages.Length].SetActive(true);
        audioClip.Play();
        audioClip.pitch = Random.Range(1f, 2f);
    }
}
