using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Resets all PlayerPrefs, for when starting the game. Resets all stored variables
        PlayerPrefs.SetInt("waterfallPuzzle", 0);
        PlayerPrefs.SetInt("morsePuzzle", 0);
        PlayerPrefs.SetInt("alignPuzzle", 0);
        PlayerPrefs.SetInt("isBroken", 0);
    }
}
