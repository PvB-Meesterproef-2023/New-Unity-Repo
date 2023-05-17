using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMorse : MonoBehaviour
{
    [SerializeField] GameObject morseParent;

    [SerializeField] Collider leftHand;
    [SerializeField] Collider rightHand;

    [SerializeField] AudioSource crowCaw;
    [SerializeField] AudioSource pling;

    [SerializeField] GameObject arrowObj;

    Vector3 moveMorse = new Vector3(0, -0.05f, 0);
    Vector3 startPos = Vector3.zero;

    public List<GameObject> morses;

    public bool startMovement = false;
    public int currentNum = 0;

    private void Start()
    {
        startPos = morseParent.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (startMovement)
        {
            morseParent.transform.localPosition += moveMorse;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col == leftHand || col == rightHand)
        {
            startMovement = true;
            morseParent.transform.localPosition = startPos;
            for (int i = 0; i < morses.Count; i++)
            {
                morses[i].SetActive(false);
            }

            morses[currentNum++].SetActive(true);

            arrowObj.transform.position = arrowObj.transform.parent.Find("pos" + currentNum).GetComponent<Transform>().transform.position;

            if (currentNum >= morses.Count)
                currentNum = 0;

            crowCaw.Play();
            StartCoroutine(waitPling());
        }
    }

    IEnumerator waitPling()
    {
        yield return new WaitForSeconds(2);
        pling.Play();
    }
}
