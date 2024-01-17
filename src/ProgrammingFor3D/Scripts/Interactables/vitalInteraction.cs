using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vitalInteraction : MonoBehaviour
{
    public Slider slider;
    //public Animator anim;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            slider.value = 1;
            //play animation to show action
        }
    }


}
