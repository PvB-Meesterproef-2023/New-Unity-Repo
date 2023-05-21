using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duckQuack : MonoBehaviour
{
    [SerializeField] AudioSource Quack; // Reference to the quack audio source
    bool hasQuacked = false; // Flag to track if the quack sound has played

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code goes here
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Rigidbody>().isKinematic && !hasQuacked)
        {
            // If the object is kinematic and the quack sound hasn't played yet
            hasQuacked = true; // Set the hasQuacked flag to true
            Quack.Play(); // Play the quack sound
        }
        if (!transform.GetComponent<Rigidbody>().isKinematic && hasQuacked)
        {
            // If the object is no longer kinematic and the quack sound has played
            hasQuacked = false; // Set the hasQuacked flag to false
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!transform.GetComponent<itemTimeout>().onStartPos)
        {
            // If the object is not on the start position (triggered by collision)
            Quack.Play(); // Play the quack sound
        }
    }
}
