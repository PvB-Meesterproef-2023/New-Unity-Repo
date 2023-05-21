using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addCorrectNum : MonoBehaviour
{
    [SerializeField] TextMesh textObj; // Serialized field for the TextMesh component used to display the code

    string[] codeArray = { "0", "0", "0", "0", "0" }; // Array to store the individual digits of the code
    string finalCode; // Variable to store the final concatenated code

    public string addNum; // Variable to store the new digit to add
    public int numPos; // Variable to store the position at which the new digit should be added

    public void addNewNum()
    {
        codeArray[numPos] = addNum; // Update the digit at the specified position in the code array with the new digit
    }

    // Update is called once per frame
    void Update()
    {
        textObj.text = ""; // Clear the text displayed by the TextMesh component

        for (int i = 0; i < codeArray.Length; i++)
        {
            textObj.text += codeArray[i]; // Concatenate each digit of the code to the text displayed by the TextMesh component
        }
    }
}
