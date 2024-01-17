using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingCabinet : MonoBehaviour
{
    public float currentTime = 0f;
    public float hideInterval;
    bool isHidden;
    playerDeath death;
    Coroutine countdown;

    private void Start()
    {
        death = FindObjectOfType<playerDeath>();
        hideInterval = Time.time + Random.Range(20f, 120f);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= hideInterval)
        {
            countdown = StartCoroutine(deathCountdown());

            hideInterval = Time.time + Random.Range(20f, 120f); //adds a delay of range (20 sec to 2 mins) between next interval to take meds;
            currentTime = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            //play anim to show player entering cabinet and then monster running past (maybe new camera with anim), then exiting the cabinet
            if (countdown != null) { StopCoroutine(countdown); }            
        }
    }

    IEnumerator deathCountdown()
    {
        //play noise of monster enterring (a howl, banging, etc..)
        Debug.Log("The monster is coming to find you");
        yield return new WaitForSeconds(15);

        death.killPlayer("The Monster Found you", 0);

    }
}
