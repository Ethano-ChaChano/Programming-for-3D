using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntryPoints;

public class entryPoint : MonoBehaviour
{
    protected gameController controller;
    [SerializeField] protected EntryPoints.place location;

    void Start()
    {
        controller = GetComponentInParent<gameController>();
        if (location == EntryPoints.place.NONE) { Debug.Log("No Entry Point Set For " + gameObject); }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") { controller.HasEntered(location); }
    }
}
