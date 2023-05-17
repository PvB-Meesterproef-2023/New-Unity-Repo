using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkKeycode : MonoBehaviour
{
    public Renderer keypadScreenRenderer;

    [SerializeField] TextMesh codeScreen;

    public string keycode;
    public string correctCode = "17698";

    public bool checkCode = false;

    [SerializeField] GameObject nextSign;

    void Update()
    {
        codeScreen.text = keycode;

        if(keycode == correctCode && checkCode)
        {
            checkCode = false;
            nextSign.SetActive(true);
            keypadScreenRenderer.material.color = Color.green;
            keycode = null;
        }
        else if (checkCode)
        {
            checkCode = false;
            keypadScreenRenderer.material.color = Color.red;
            keycode = null;
        }
    }
}
