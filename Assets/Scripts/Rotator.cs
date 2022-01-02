using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 rotatePerSec;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotatePerSec * Time.deltaTime);
    }
}
