using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFishAlign : MonoBehaviour
{
    [SerializeField] Collider scareObj; // Serialized field for the scare collider
    [SerializeField] GameObject birdButton; // Serialized field for the bird button game object

    Vector3 moveSpeed = new Vector3(0, 0, 1); // Speed at which the object moves
    Vector3 startPos = Vector3.zero; // Starting position of the object

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition; // Store the starting position of the object
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == scareObj) // Check if the collider is the scare collider
        {
            if (gameObject.transform.localPosition.z < (startPos.z - 0.5f)) // Check if the object's position is less than the threshold position
            {
                gameObject.transform.localPosition += moveSpeed; // Move the object in the positive z-direction
            }
            else
            {
                birdButton.GetComponent<birdButton>().fishAligned = true; // Set the fishAligned flag in the birdButton script to true
            }
        }
    }
}
