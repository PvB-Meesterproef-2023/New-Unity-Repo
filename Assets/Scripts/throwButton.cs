using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwButton : MonoBehaviour
{
    [SerializeField] AudioSource pling;
    [SerializeField] GameObject throwItem;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == throwItem.name)
        {
            pling.Play();
        }
    }
}
