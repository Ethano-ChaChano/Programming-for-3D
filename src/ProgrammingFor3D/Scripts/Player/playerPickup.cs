using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPickup : MonoBehaviour
{
    public int rotAmount = 5;
    public Camera cam;
    public LayerMask mask;
    public GameObject hand;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) { grabItem(); } //detects when the player has clicked (to try and pick up an item)
        if (hand.transform.childCount >= 1) { rotateItem(); } //true when player is holding an item
    }

    void grabItem()
    {
        //If the player is already holding an item, drop that item
        if (hand.transform.childCount >= 1)
        {
            hand.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            hand.transform.GetChild(0).gameObject.layer = 10;
            hand.transform.GetChild(0).parent = null;
        }
        //Otherwise, shoot a raycast and if it hits an object that can be picked up, set its parent to the player
        else
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10, mask))
            {
                hit.rigidbody.isKinematic = true;

                hit.transform.SetParent(hand.transform);
                hit.transform.position = hand.transform.position;
                hit.transform.gameObject.layer = 11;
            }
        }
    }

    //Called when player is holding an item
    void rotateItem()
    {
        if (Input.GetKey(KeyCode.Q)) { hand.transform.localRotation *= Quaternion.Euler(0, rotAmount, 0); }
        if (Input.GetKey(KeyCode.E)) { hand.transform.localRotation *= Quaternion.Euler(0, -rotAmount, 0); }
        if (Input.GetMouseButtonDown(1)) { hand.transform.GetChild(0).rotation = Quaternion.identity; }
    }
}
