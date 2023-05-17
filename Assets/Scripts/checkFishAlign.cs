using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFishAlign : MonoBehaviour
{
    [SerializeField] Collider scareObj;
    [SerializeField] GameObject birdButton;

    Vector3 moveSpeed = new Vector3(0, 0, 1);
    Vector3 startPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == scareObj)
        {
            if (gameObject.transform.localPosition.z < (startPos.z - 0.5f))
            {
                gameObject.transform.localPosition += moveSpeed;
            }
            else birdButton.GetComponent<birdButton>().fishAligned = true;
        }
    }
}
