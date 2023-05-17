using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duckQuack : MonoBehaviour
{
    [SerializeField] AudioSource Quack;
    bool hasQuacked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Rigidbody>().isKinematic && !hasQuacked)
        {
            hasQuacked = true;
            Quack.Play();
        }
        if(!transform.GetComponent<Rigidbody>().isKinematic && hasQuacked)
        {
            hasQuacked = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(!transform.GetComponent<itemTimeout>().onStartPos)
            Quack.Play();
    }
}
