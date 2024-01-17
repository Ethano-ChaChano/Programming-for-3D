using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public int speed;
    public int normalSpeed = 5;
    public int sneakSpeed = 3;

    public float gravity = 0.5f;

    [Header("Look Settings")]
    public float lookSensitivity = 5;
    float lookX;
    float lookY;

    public Animator anim;
    public AudioSource clip;
    public Transform hand;
    public GameObject monster;
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
        if (monster != null)
        {
            movement();
            sneak();
            look();
            if (!controller.isGrounded) { position.y -= gravity * Time.deltaTime; } //gravity

            position = transform.TransformDirection(position);
            controller.Move(position * Time.deltaTime);
        }
    }

    void movement() {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        position.x = movement.x * speed;   //affects players x-axis
        position.z = movement.y * speed;   //affects players z-axis

        //If Moving (and not holding or holding)
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !(hand.childCount > 0)) { anim.SetBool("isWalk", true); if (!clip.isPlaying) { clip.Play(); } }
        else if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && hand.childCount > 0) { anim.SetBool("isHolding", true); if (!clip.isPlaying) { clip.Play(); } }
        else { anim.SetBool("isWalk", false); anim.SetBool("isHolding", false); clip.Stop(); }
    }

    void sneak()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)) { controller.height = 1; speed = sneakSpeed; anim.SetBool("isCrouch", true); }
        else { controller.height = 2; speed = normalSpeed; anim.SetBool("isCrouch", false); }
    }

    void look() {
        lookX += Input.GetAxis("Mouse X") * lookSensitivity;
        lookY += Input.GetAxis("Mouse Y") * lookSensitivity;

        lookY = Mathf.Clamp(lookY, -60, 90);

        cam.transform.localRotation = Quaternion.Euler(-lookY, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookX, 0);
    }
}
