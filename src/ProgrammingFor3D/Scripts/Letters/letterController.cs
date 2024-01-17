using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterController : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        { 
            canvas.gameObject.SetActive(true);
            Destroy(transform.GetChild(1).gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            canvas.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
