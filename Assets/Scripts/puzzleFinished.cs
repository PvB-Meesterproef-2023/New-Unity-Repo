using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleFinished : MonoBehaviour
{
    private bool waterfallPuzzle = false;
    private bool morsePuzzle = false;
    private bool alignPuzzle = false;

    [SerializeField] GameObject doorText;

    public string puzzleName;
    // Start is called before the first frame update
    void Start()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt(puzzleName)))
        {
            gameObject.GetComponentInChildren<Light>().enabled = false;
            doorText.SetActive(true);
        }
    }
}
