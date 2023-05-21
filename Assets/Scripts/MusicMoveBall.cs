using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMoveBall : MonoBehaviour
{

    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        // move collision gameobject towards target with force
        collision.gameObject.GetComponent<Rigidbody>().AddForce((target.transform.position - collision.gameObject.transform.position) * 10, ForceMode.Acceleration);
    }
}
