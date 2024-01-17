using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycasterWorld : GraphicRaycaster
{
    public GameObject monster;

    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
        //Set eventdata to the middle of the screen if the monster is alive, otherwise set it to the mouse position
        if (monster != null) { eventData.position = new(Screen.width / 2, Screen.height / 2); }
        else { eventData.position = Input.mousePosition; }

        base.Raycast(eventData, resultAppendList);
    }
}