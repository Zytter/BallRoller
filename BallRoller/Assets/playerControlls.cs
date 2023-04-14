using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    public float gravity = 9.8f;
    public float cameraSensitivity = 5.0f;
    public float cameraSmoothness = 0.1f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float cameraAngleX = 0.0f;
    private float cameraAngleY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player forward/backward and left/right
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);
        movement *= speed;
        characterController.Move(movement * Time.deltaTime);

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        // Jump
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        // Rotate the camera horizontally
        cameraAngleX += Input.GetAxis("Mouse X") * cameraSensitivity;
        Quaternion cameraRotationX = Quaternion.AngleAxis(cameraAngleX, Vector3.up);
        transform.localRotation = cameraRotationX;

        // Rotate the camera vertically
        cameraAngleY -= Input.GetAxis("Mouse Y") * cameraSensitivity;
        cameraAngleY = Mathf.Clamp(cameraAngleY, -90, 90);
        Quaternion cameraRotationY = Quaternion.AngleAxis(cameraAngleY, Vector3.right);
        Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation, cameraRotationY, cameraSmoothness);
    }
}