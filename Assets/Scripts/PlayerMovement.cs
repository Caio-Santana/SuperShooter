using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody rb;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        // Moving thru tranform
        //transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        rb.AddRelativeTorque(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.W))
        {
            // Moving thru transform
            //transform.Translate(0, 0, speed * Time.deltaTime);
            rb.AddRelativeForce(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(0, 0, -speed * Time.deltaTime);
            rb.AddRelativeForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(-speed * Time.deltaTime, 0, 0);
            rb.AddRelativeForce(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(speed * Time.deltaTime, 0, 0);
            rb.AddRelativeForce(speed * Time.deltaTime, 0, 0);
        }

    }
}
