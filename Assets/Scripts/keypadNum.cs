using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class keypadNum : MonoBehaviour
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
        Debug.Log("HIT");
        if (col == pokePointLeft || col == pokePointRight)
        {
            Debug.Log("Checking number");
            switch (gameObject.name)
            {
                case "reset":
                    gameObject.transform.parent.GetComponent<checkKeycode>().keycode = null;
                    keyRenderer.material.color = Color.cyan;
                    break;
                case "enter":
                    gameObject.transform.parent.GetComponent<checkKeycode>().checkCode = true;
                    keyRenderer.material.color = Color.cyan;
                    break;
                default:
                    keyRenderer.material.color = Color.cyan;
                    gameObject.transform.parent.GetComponent<checkKeycode>().keycode += gameObject.name;
                    if(gameObject.name == "1" || gameObject.name == "7" || gameObject.name == "6" || gameObject.name == "9" || gameObject.name == "8")
                    {
                        gameObject.transform.parent.GetComponent<addCorrectNum>().addNum = gameObject.name;
                        gameObject.transform.parent.GetComponent<addCorrectNum>().numPos = gameObject.transform.GetSiblingIndex();
                        gameObject.transform.parent.GetComponent<addCorrectNum>().addNewNum();
                    }
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        keyRenderer.material.color = Color.gray;

    }
}
