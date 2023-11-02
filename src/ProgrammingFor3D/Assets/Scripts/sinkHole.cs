using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkHole : entryPoint
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") { controller.hasFallen = true; }
    }
}