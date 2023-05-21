using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkScared : MonoBehaviour
{
    [SerializeField] Collider scareObj; // Reference to the scare collider

    Vector3 moveSpeed = new Vector3(0, 0, 1); // The speed at which the object moves
    Vector3 startPos = Vector3.zero; // The starting position of the object

    public bool birdAligned = false; // Flag to indicate if the birds are aligned
    public bool fishAligned = false; // Flag to indicate if the fish are aligned

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition; // Store the starting position of the object
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == scareObj) // Check if the scare collider is triggered
        {
            if (gameObject.name == "finalVogels" && gameObject.transform.localPosition.z > (startPos.z + 0.5f))
            {
                // If the object is the finalVogels and its local position in the z-axis is greater than the starting position + 0.5
                gameObject.transform.localPosition -= moveSpeed; // Move the object in the negative z-axis direction
            }
            else if (gameObject.name == "finalVogels")
            {
                birdAligned = true; // Set the birdAligned flag to true
            }

            if (gameObject.name == "finalVissen" && gameObject.transform.localPosition.z < (startPos.z - 0.5f))
            {
                // If the object is the finalVissen and its local position in the z-axis is less than the starting position - 0.5
                gameObject.transform.localPosition += moveSpeed; // Move the object in the positive z-axis direction
            }
            else if (gameObject.name == "finalVissen")
            {
                fishAligned = true; // Set the fishAligned flag to true
            }

            Debug.Log("Fish: " + fishAligned); // Output the state of fishAligned
            Debug.Log("Birds: " + birdAligned); // Output the state of birdAligned
        }
    }
}
