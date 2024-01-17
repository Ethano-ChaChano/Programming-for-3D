using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class doorManager : MonoBehaviour
{
    public Animator doorAnimation;
    AudioSource audioClip;

    private void Start()
    {
        audioClip = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && doorAnimation != null)
        {
            audioClip.Play();
            audioClip.pitch = Random.Range(1f, 2f);
            doorAnimation.SetBool("isOpened", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && doorAnimation != null)
        {
            //audioClip.Play();
            doorAnimation.SetBool("isOpened", false);
        }
    }
}
