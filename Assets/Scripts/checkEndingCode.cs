using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkEndingCode : MonoBehaviour
{
    public Renderer keypadScreenRenderer;

    [SerializeField] TextMesh codeScreen;
    [SerializeField] Collider endingDoorCol;
    [SerializeField] AudioSource endingCaw;

    public string keycode;
    public string correctCode = "17698";

    public bool checkCode = false;

    void Update()
    {
        codeScreen.text = keycode;

        if (keycode == correctCode && checkCode)
        {
            checkCode = false;
            keypadScreenRenderer.material.color = Color.green;
            keycode = null;
            endingDoorCol.enabled = true;
            endingCaw.Play();
        }
        else if (checkCode)
        {
            checkCode = false;
            keypadScreenRenderer.material.color = Color.red;
            keycode = null;
        }
    }
}
