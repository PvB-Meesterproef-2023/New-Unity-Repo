using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleFinished : MonoBehaviour
{
    private bool waterfallPuzzle = false; // Flag indicating whether the waterfall puzzle is solved or not.
    private bool morsePuzzle = false; // Flag indicating whether the morse puzzle is solved or not.
    private bool alignPuzzle = false; // Flag indicating whether the align puzzle is solved or not.

    [SerializeField] GameObject doorText; // Reference to the door text GameObject in the scene.

    public string puzzleName; // Name of the puzzle associated with this script.

    // Start is called before the first frame update
    void Start()
    {
        // Check if the puzzle associated with this script is already solved.
        // If the puzzle is solved, disable the light component of the current game object
        // and activate the door text GameObject.
        if (Convert.ToBoolean(PlayerPrefs.GetInt(puzzleName)))
        {
            gameObject.GetComponentInChildren<Light>().enabled = false; // Disable the light component.
            doorText.SetActive(true); // Activate the door text GameObject.
        }
    }
}
