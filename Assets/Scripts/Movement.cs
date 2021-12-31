using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustSpeed = 250f;
    [SerializeField] float rotateSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Pressing left and right.");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            RocketRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RocketRotation(-rotateSpeed);
        }
    }

    void RocketRotation(float currentRotate)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * currentRotate * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
