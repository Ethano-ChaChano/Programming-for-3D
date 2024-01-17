using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterAI : MonoBehaviour
{
    public int movementSpeed;
    public int distanceThreshold;
    public GameObject[] nodepoints;
    public Transform playerHand;
    public GameObject winScreen;
    
    private Vector3 selectedPoint;

    playerDeath death;
    Animator anim;

    private void Start()
    {
        StartCoroutine(moveToPoint());
        death = FindObjectOfType<playerDeath>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.LookAt(selectedPoint);
        if (Vector3.Distance(transform.position, selectedPoint) > distanceThreshold)
        {
            anim.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, selectedPoint, movementSpeed * Time.deltaTime);
        }
        else { anim.SetBool("isWalking", false); }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player"))
        {
            if (playerHand.childCount >= 1 && playerHand.GetChild(0).CompareTag("Weapon"))
            {
                killMonster();
                return;
            }
         
            death.killPlayer("The monster got you, you have died", 0);
            transform.LookAt(other.transform);
            selectedPoint = other.transform.position;
        }
    }


    IEnumerator moveToPoint() {
        selectedPoint = nodepoints[Random.Range(0, nodepoints.Length)].transform.position;

        yield return new WaitForSeconds(Random.Range(5, 15));
        StartCoroutine(moveToPoint());
    }

    void killMonster() 
    {
        Destroy(gameObject, .75f);

        winScreen.SetActive(true);
        winScreen.GetComponent<Animation>().Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
