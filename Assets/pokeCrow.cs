using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeCrow : MonoBehaviour
{
    // VR controller poke sticks, top part sphere colliders
    [SerializeField] AudioSource crowSound;
    [SerializeField] Collider leftPokePoint;
    [SerializeField] Collider rightPokePoint;

    private void OnTriggerEnter(Collider col)
    {
        // Check if the collider that entered is either leftPokePoint or rightPokePoint
        if (col == leftPokePoint || col == rightPokePoint)
        {
            // Play the crow sound effect
            crowSound.Play();
        }
    }
}
