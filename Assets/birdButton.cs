using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdButton : MonoBehaviour
{
    [SerializeField] Collider pokeColliderLeft; // Serialized field for the collider representing the left poke collider
    [SerializeField] Collider pokeColliderRight; // Serialized field for the collider representing the right poke collider
    [SerializeField] GameObject bird; // Serialized field for the bird game object
    [SerializeField] GameObject nextPuzzle; // Serialized field for the next puzzle game object
    [SerializeField] AudioSource errorSFX; // Serialized field for the error sound audio source

    bool isAligned = false; // Flag indicating if the bird and fish are aligned
    public bool fishAligned = false; // Flag indicating if the fish is aligned
    public bool birdAligned = false; // Flag indicating if the bird is aligned

    public void OnTriggerEnter(Collider col)
    {
        if (birdAligned && fishAligned && !isAligned) // Check if both the bird and fish are aligned and if they are not already aligned
        {
            isAligned = true; // Set the alignment flag to true
            gameObject.transform.parent.GetComponent<birdFishAlign>().alignBirdsFish(); // Invoke the alignBirdsFish() method in the parent game object's birdFishAlign script
            nextPuzzle.SetActive(true); // Activate the next puzzle game object
        }
        else if (!isAligned)
        {
            errorSFX.Play(); // Play the error sound if the bird and fish are not aligned
        }
    }

}
