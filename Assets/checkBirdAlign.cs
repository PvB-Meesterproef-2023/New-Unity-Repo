using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBirdAlign : MonoBehaviour
{
    [SerializeField] Collider scareObj; // Serialized field for the collider object
    [SerializeField] GameObject birdButton; // Serialized field for the bird button object

    Vector3 moveSpeed = new Vector3(0, 0, 1); // Speed at which the object moves
    Vector3 startPos = Vector3.zero; // Initial position of the object

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition; // Set the initial position of the object to its local position
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == scareObj) // Check if the collider that triggered the event is the scare object
        {
            if (gameObject.transform.localPosition.z > (startPos.z + 0.5f)) // Check if the object has moved more than 0.5 units in the z direction from its starting position
            {
                gameObject.transform.localPosition -= moveSpeed; // Move the object backwards by subtracting the moveSpeed vector from its local position
            }
            else
            {
                birdButton.GetComponent<birdButton>().birdAligned = true; // Set the birdAligned property of the bird button script to true, indicating that the bird is aligned
            }
        }
    }
}
