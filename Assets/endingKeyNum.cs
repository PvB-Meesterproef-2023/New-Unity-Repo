using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingKeyNum : MonoBehaviour
{
    Renderer keyRenderer; // Reference to the key renderer

    [SerializeField] Collider pokePointLeft; // Collider representing the left poke point
    [SerializeField] Collider pokePointRight; // Collider representing the right poke point

    int keyNum; // Variable to store the key number

    private void Start()
    {
        keyRenderer = gameObject.GetComponent<Renderer>(); // Get the key renderer component
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == pokePointLeft || col == pokePointRight)
        {
            keyRenderer.material.color = Color.cyan; // Change the key renderer's color to cyan

            switch (gameObject.name)
            {
                case "reset":
                    gameObject.transform.parent.GetComponent<checkEndingCode>().keycode = null; // Reset the keycode to null
                    break;
                case "enter":
                    gameObject.transform.parent.GetComponent<checkEndingCode>().checkCode = true; // Set the checkCode flag to true
                    break;
                default:
                    gameObject.transform.parent.GetComponent<checkEndingCode>().keycode += gameObject.name; // Append the key's name to the keycode
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        keyRenderer.material.color = Color.gray; // Change the key renderer's color to gray
    }
}
