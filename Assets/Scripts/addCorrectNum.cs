using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addCorrectNum : MonoBehaviour
{
    [SerializeField] TextMesh textObj;

    string[] codeArray = { "0", "0", "0", "0", "0" };
    string finalCode;

    public string addNum;
    public int numPos;

    public void addNewNum()
    {
        codeArray[numPos] = addNum;
    }

    // Update is called once per frame
    void Update()
    {
        textObj.text = "";
        for (int i = 0; i < codeArray.Length; i++)
        {
            textObj.text += codeArray[i];
        }
    }
}
