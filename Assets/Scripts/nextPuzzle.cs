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
        puzzleFinished.Play();
        PlayerPrefs.SetInt(puzzleName, 1);
    }
}
