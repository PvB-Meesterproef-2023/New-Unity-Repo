using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerUp : MonoBehaviour
{
    // !! SCRIPT NO LONGER USED
    // Update is called once per frame
    void Update()
    {
        // Resetting rotation around the z-axis to 0
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);

        // Getting the velocity of the object's rigidbody in the x-z plane
        Vector3 xzAxis = transform.GetComponent<Rigidbody>().velocity;
        xzAxis.x = 0; // Setting the x-axis velocity to 0
        xzAxis.z = 0; // Setting the z-axis velocity to 0

        // Setting the rotation of the object's rigidbody to the modified velocity vector
        // transform.GetComponent<Rigidbody>().rotation = xzAxis;
    }
}
