using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeButton : MonoBehaviour
{
    // VR controller poke sticks, top part sphere colliders
    [SerializeField] Collider pokeColliderLeft;
    [SerializeField] Collider pokeColliderRight;

    // Audio source for correct action triggered
    public AudioSource pling;

    public void OnTriggerEnter(Collider col)
    {
        // Check if the collider that entered is either pokeColliderLeft or pokeColliderRight
        if (col == pokeColliderLeft || col == pokeColliderRight)
        {
            // Play the "pling" sound effect
            pling.Play();
        }
    }

}
