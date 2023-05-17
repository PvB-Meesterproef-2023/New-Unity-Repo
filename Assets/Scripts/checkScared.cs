using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkScared : MonoBehaviour
{
    [SerializeField] Collider scareObj;
    Vector3 moveSpeed = new Vector3(0, 0, 1);
    Vector3 startPos = Vector3.zero;

    public bool birdAligned = false;
    public bool fishAligned = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == scareObj)
        {
            if (gameObject.name == "finalVogels" && gameObject.transform.localPosition.z > (startPos.z + 0.5f))
            {
                gameObject.transform.localPosition -= moveSpeed;
            }
            else if(gameObject.name == "finalVogels") birdAligned = true;
            if (gameObject.name == "finalVissen" && gameObject.transform.localPosition.z < (startPos.z - 0.5f))
            {
                gameObject.transform.localPosition += moveSpeed;
            }
            else if(gameObject.name == "finalVissen") fishAligned = true;

            Debug.Log("Fish: " + fishAligned);
            Debug.Log("Birds: " + birdAligned);
        }
    }
}
