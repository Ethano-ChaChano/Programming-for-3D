using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMover : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Animator platform;
    [SerializeField] private string animParam = "isMoving";

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(playerTag)) { 
            if (platform != null) { platform.SetBool(animParam, true); } 
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag(playerTag)) {
            if (platform != null) { platform.SetBool(animParam, false); }            
        }
    }
}
