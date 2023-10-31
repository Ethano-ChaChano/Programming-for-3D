using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public int speed = 5;
    public int jumpHeight = 5;
    public float gravity = 0.5f;

    [Header("Look Settings")]
    public float lookSensitivity = 5;
    float lookX;
    float lookY;

    CharacterController controller;
    Camera cam;
    Vector3 position = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        movement();
        jump();
        look();

        position = transform.TransformDirection(position);
        controller.Move(position * Time.deltaTime);
    }

    void movement() {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        position.x = movement.x * speed;   //affects players x-axis
        position.z = movement.y * speed;   //affects players z-axis
    }

    void jump() {
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded){position.y = jumpHeight;}
        if (!controller.isGrounded) { position.y -= gravity * Time.deltaTime; } //gravity
    }

    void look() {
        lookX += Input.GetAxis("Mouse X") * lookSensitivity;
        lookY += Input.GetAxis("Mouse Y") * lookSensitivity;

        lookY = Mathf.Clamp(lookY, -60, 90);

        cam.transform.localRotation = Quaternion.Euler(-lookY, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookX, 0);
    }
}
