using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class interactionItem : MonoBehaviour
{
    public string Name;
    [TextArea(5, 10)]
    public string Description;

    public bool isUnlocked;
    public Animation interactionAnim;
    //public AudioClip interactionAudio;

    //public dialogue
    public interactionManager manager;

    private void start()
    {
        //manager = FindObjectOfType<interactionManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isUnlocked)
        {
            manager.buttonPrompt.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //manager.investigationScreen.gameObject.SetActive(true);
                manager.tmpName.text = Name.ToUpper();
                manager.tmpDescription.text = Description;

                //play anim, audio, dialogue
                interactionAnim.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.buttonPrompt.gameObject.SetActive(false);
            //manager.investigationScreen.gameObject.SetActive(false);
        }
    }
}
