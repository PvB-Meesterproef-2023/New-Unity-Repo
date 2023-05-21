using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextPuzzle : MonoBehaviour
{
    [SerializeField] private string puzzleName;
    [SerializeField] AudioSource puzzleFinished;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the puzzle has been completed based on the puzzleName
        if (PlayerPrefs.GetInt(puzzleName) == 0)
        {
            // Play the puzzle finished sound effect
            puzzleFinished.Play();

            // Mark the puzzle as completed by setting the puzzleName in PlayerPrefs to 1
            PlayerPrefs.SetInt(puzzleName, 1);
        }
    }

}
