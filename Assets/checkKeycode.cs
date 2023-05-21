using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkKeycode : MonoBehaviour
{
    public Renderer keypadScreenRenderer; // Reference to the keypad screen renderer

    [SerializeField] TextMesh codeScreen; // Reference to the text mesh for displaying the entered code

    public string keycode; // Stores the entered keycode
    public string correctCode = "17698"; // The correct keycode to compare against

    public bool checkCode = false; // Flag to indicate whether to check the entered code

    [SerializeField] GameObject nextSign; // Reference to the next sign object

    void Update()
    {
        codeScreen.text = keycode; // Update the text on the code screen with the entered keycode

        if (keycode == correctCode && checkCode) // Check if the entered keycode matches the correct code and the checkCode flag is set
        {
            checkCode = false; // Reset the checkCode flag
            nextSign.SetActive(true); // Activate the next sign object
            keypadScreenRenderer.material.color = Color.green; // Set the keypad screen color to green
            keycode = null; // Reset the entered keycode
        }
        else if (checkCode) // If the checkCode flag is set (meaning the keycode was entered), but it doesn't match the correct code
        {
            checkCode = false; // Reset the checkCode flag
            keypadScreenRenderer.material.color = Color.red; // Set the keypad screen color to red
            keycode = null; // Reset the entered keycode
        }
    }
}
