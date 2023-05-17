using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkIntroEnding : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(toNextPuzzle());
    }
    IEnumerator toNextPuzzle()
    {
        yield return new WaitForSeconds(7.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
