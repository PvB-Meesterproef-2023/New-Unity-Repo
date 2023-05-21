using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkIntroEnding : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(toNextPuzzle()); // Start the coroutine to transition to the next puzzle
    }

    IEnumerator toNextPuzzle()
    {
        yield return new WaitForSeconds(7.5f); // Wait for 7.5 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene in the build index
    }

}
