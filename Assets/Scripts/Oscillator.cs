using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period;
    float movementFactor;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        
        float cycles = Time.time / period; // Growing over time
        const float tau = Mathf.PI * 2;      // Get tau
        float sinWay = Mathf.Sin(cycles * tau); // Get result of sin between -1 and 1
        movementFactor = (sinWay + 1f) / 2f; // make -1 and 1 to 0 and 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
