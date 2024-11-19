using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5.0f;
    public float maxWalkingSpeed = 1000f;
    public float mouseSensitivity = 2.0f;

    private float verticalRotation = 0;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotationInputM();
        WASD();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = maxWalkingSpeed * 3;
        }
        else
        {
            movementSpeed = maxWalkingSpeed;
        }
    }

    void RotationInputM()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void WASD()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * movementSpeed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
