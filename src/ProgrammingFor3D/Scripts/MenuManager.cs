using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    AudioSource audioClip;

    private void Start()
    {
        audioClip = GetComponent<AudioSource>();
    }

    public void menu() { audioClip.Play(); SceneManager.LoadScene(0); }
    public void loadGame() { audioClip.Play(); SceneManager.LoadScene(1); }
    public void quit() { audioClip.Play(); Application.Quit(); }
}
