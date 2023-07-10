using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRay : MonoBehaviour
{
    // Draw a ray to know where the character is looking at
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
