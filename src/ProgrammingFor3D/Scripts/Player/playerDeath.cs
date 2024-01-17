using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDeath : MonoBehaviour
{
    public Animator anim;
    AudioSource audioClip;
    playerMovement movement;
    //public GameObject playerCam;
    public TMP_Text deathText;
    public GameObject monster;

    bool isDead;

    private void Start()
    {
        movement = FindObjectOfType<playerMovement>();
        audioClip = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { killPlayer("Pausing to take a break is a definite way to get killed...", 0); }
    }



    //Calls the coroutine to kill the player if they are not yet dead
    public void killPlayer(string deathText, float timeTillDeath) 
    {
        if (!isDead && monster != null)
        {
            StartCoroutine(PlayerDeath(deathText, timeTillDeath));
        }
    }

    //Display the death UI, jumpscare, and audio. Set the player to dead
    IEnumerator PlayerDeath(string text, float timeTillDeath)
    {
        yield return new WaitForSeconds(timeTillDeath);

        deathText.text = text.ToUpper();
        movement.lookSensitivity = 0;
        movement.speed = 0;

        Destroy(monster);
        anim.SetBool("isDead", true);
        audioClip.Play();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isDead = true;
    }
}
