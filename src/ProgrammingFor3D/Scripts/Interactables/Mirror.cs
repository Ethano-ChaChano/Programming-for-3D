using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Transform playerCamera;
    public Transform cam;
    public Transform otherPortal;
    public float offset;

    void LateUpdate()
    {
        //Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        //transform.position = cam.position + playerOffsetFromPortal;

        //float angularDifferenceBetweenPortalRotations = Quaternion.Angle(cam.rotation, otherPortal.rotation);

        //Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        //Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        //transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        cam.position = new Vector3(cam.position.x, playerCamera.position.y + offset, cam.position.z);

    }
}
