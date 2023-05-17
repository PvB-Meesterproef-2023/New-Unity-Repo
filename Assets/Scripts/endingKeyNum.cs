using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingKeyNum : MonoBehaviour
{
    Renderer keyRenderer;

    [SerializeField] Collider pokePointLeft;
    [SerializeField] Collider pokePointRight;

    int keyNum;

    private void Start()
    {
        keyRenderer = gameObject.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == pokePointLeft || col == pokePointRight)
        {
            keyRenderer.material.color = Color.cyan;
            switch (gameObject.name)
            {
                case "reset":
                    gameObject.transform.parent.GetComponent<checkEndingCode>().keycode = null;
                    break;
                case "enter":
                    gameObject.transform.parent.GetComponent<checkEndingCode>().checkCode = true;
                    break;
                default:
                    gameObject.transform.parent.GetComponent<checkEndingCode>().keycode += gameObject.name;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        keyRenderer.material.color = Color.gray;

    }
}
