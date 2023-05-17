using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFishAlign : MonoBehaviour
{
    [SerializeField] GameObject birds;
    [SerializeField] GameObject fish;

    Vector3 misalignAnimals = new Vector3(0, 0, 5);
    Vector3 misalignVertical = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitMisalign());
    }

    IEnumerator waitMisalign()
    {
        yield return new WaitForSeconds(1);
        birds.transform.localPosition += misalignAnimals;
        fish.transform.localPosition -= misalignAnimals;
        birds.transform.localPosition -= misalignVertical;
    }

    public void alignBirdsFish()
    {
        birds.transform.localPosition += misalignVertical;
    }
}
