using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class itemTimeout : MonoBehaviour
{
    [SerializeField] GameObject originalParent;
    [SerializeField] GameObject safeZone;

    public int despawnDelay = 5;

    public bool onStartPos = true;
    bool isWaiting = false;
    Vector3 startingPos;

    private void Start()
    {
        startingPos = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onStartPos && !gameObject.GetComponent<Rigidbody>().isKinematic && !isWaiting)
        {
            isWaiting = true;
            StartCoroutine(WaitForFunction());
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject == safeZone)
        {
            onStartPos = false;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == safeZone)
        {
            onStartPos = true;
        }
    }

    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(despawnDelay);
        isWaiting = false;
        resetPiece();
    }

    void resetPiece()
    {
        if (!onStartPos && !gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            onStartPos = true;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.transform.parent = originalParent.transform;
            gameObject.transform.localPosition = startingPos;
            Debug.Log("RESET");
        }
    }
}
