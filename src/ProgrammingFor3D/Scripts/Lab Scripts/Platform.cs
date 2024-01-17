using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(playerTag)) { collider.transform.SetParent(transform); }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag(playerTag)) { collider.transform.SetParent(null); }
    }
}
