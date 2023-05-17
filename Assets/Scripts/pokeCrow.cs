using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeCrow : MonoBehaviour
{
    [SerializeField] AudioSource crowSound;
    [SerializeField] Collider leftPokePoint;
    [SerializeField] Collider rightPokePoint;

    private void OnTriggerEnter(Collider col)
    {
        if (col == leftPokePoint || col == rightPokePoint)
            crowSound.Play();
    }
}
