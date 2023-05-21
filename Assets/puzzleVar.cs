using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleVar : MonoBehaviour
{
    public int figurinePlaced = 0;
    [SerializeField] GameObject nextPuzzleSign;

    // Update is called once per frame
    void Update()
    {
        if(figurinePlaced == 4)
        {
            // If all 4 figurines are placed, sets nextPuzzle sign with number on active
            nextPuzzleSign.SetActive(true);
        }
    }
}
