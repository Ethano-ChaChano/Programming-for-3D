using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerVitals : MonoBehaviour
{
    public Slider sanity;
    public Slider hydration;
    public Slider sleep;
    public Slider countdown;

    public Animator anim;

    playerDeath death;
    
    public float gameplayTime = 600f;
    public float currentTime = 0f;

    string sanityDeath = "The monster takes advantage of your delirious state. You have died";
    string hydrationDeath = "Your body fails you due to a lack of water, the monster quickly gets you while you are unconscious";
    string sleepDeath = "You pass out from exhaustion. The lack of sleep finally got the better of you";
    string timerDeath = "The monster has broken in. You have been caught";

    private void Start()
    {
        death = FindObjectOfType<playerDeath>();
    }


    void Update()
    {
        //If any of the vitals are below than a certain amount, play animation to indicate death soon
        if (sanity.value <= 0.2 || hydration.value <= 0.2 || sleep.value <= 0.2) { anim.SetBool("isDying", true); }
        else { anim.SetBool("isDying", false); }

        //Constanly decrease the values if it is not zero. otherwise kill the player
        if (sanity.value > 0) { sanity.value -= Time.deltaTime / 150; } else { death.killPlayer(sanityDeath, 0); }
        if (hydration.value > 0) { hydration.value -= Time.deltaTime / 175; } else { death.killPlayer(hydrationDeath, 0); }
        if (sleep.value > 0) { sleep.value -= Time.deltaTime / 200; } else { death.killPlayer(sleepDeath, 0); }        
        
        //10 minute timer for the player.
        //If the player does not beat the game in 10 minutes, kill them to restart the game
        currentTime += Time.deltaTime;
        countdown.value = 1 - (currentTime/gameplayTime);
        if (currentTime >= gameplayTime)
        {
            death.killPlayer(timerDeath, 0);
        }
    }
}
