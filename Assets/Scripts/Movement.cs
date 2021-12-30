using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("Pressing space.");
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
            Debug.Log("Pressing left.");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Pressing right.");
        }
    }
}
