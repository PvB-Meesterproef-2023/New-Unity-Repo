using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerUp : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        Vector3 xzAxis = transform.GetComponent<Rigidbody>().velocity;
        xzAxis.x = 0;
        xzAxis.z = 0;
        // transform.GetComponent<Rigidbody>().rotation = xzAxis;
    }
}
