using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkEndingCode : MonoBehaviour
{
    public Renderer keypadScreenRenderer; // Reference to the renderer component of the keypad screen

    [SerializeField] TextMesh codeScreen; // Serialized field for the TextMesh component used for displaying the entered code
    [SerializeField] Collider endingDoorCol; // Serialized field for the collider of the ending door
    [SerializeField] AudioSource endingCaw; // Serialized field for the AudioSource component for the ending caw sound

    public string keycode; // Variable to store the entered keycode
    public string correctCode = "073"; // The correct keycode

    public bool checkCode = false; // Flag to check if the code should be validated

    void Update()
    {
        codeScreen.text = keycode; // Update the text on the code screen to display the entered keycode

        if (keycode == correctCode && checkCode) // Check if the entered keycode matches the correct code and if code validation is required
        {
            checkCode = false; // Disable code validation to prevent further checks

            keypadScreenRenderer.material.color = Color.green; // Change the color of the keypad screen to green
            keycode = null; // Reset the entered keycode to null

            endingDoorCol.enabled = true; // Enable the collider of the ending door
            endingCaw.Play(); // Play the ending caw sound
        }
        else if (checkCode) // If code validation is required but the entered keycode is incorrect
        {
            checkCode = false; // Disable code validation to prevent further checks

            keypadScreenRenderer.material.color = Color.red; // Change the color of the keypad screen to red
            keycode = null; // Reset the entered keycode to null
        }
    }
}
