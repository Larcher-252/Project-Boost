using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    [SerializeField] Vector3 movementSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += movementSpeed * Time.deltaTime;
    }
}
