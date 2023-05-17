using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeFigurine : MonoBehaviour
{
    [SerializeField] GameObject figurineObject;
    [SerializeField] GameObject staticObject;
    [SerializeField] GameObject outlineObject;

    private void Start()
    {
        staticObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(figurineObject == col.gameObject)
        {
            col.gameObject.SetActive(false);
            staticObject.SetActive(true);
            outlineObject.SetActive(false);
            gameObject.transform.parent.GetComponentInParent<puzzleVar>().figurinePlaced++;
        }
    }
}
