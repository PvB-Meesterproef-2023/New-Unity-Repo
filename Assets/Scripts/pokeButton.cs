using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeButton : MonoBehaviour
{
    [SerializeField] Collider pokeColliderLeft;
    [SerializeField] Collider pokeColliderRight;
    public AudioSource pling;

    public void OnTriggerEnter(Collider col)
    {
        if(col == pokeColliderLeft || col == pokeColliderRight)
        {
            pling.Play();
        }
    }
}
