using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFishAlign : MonoBehaviour
{
    [SerializeField] GameObject birds; // Serialized field for the birds game object
    [SerializeField] GameObject fish; // Serialized field for the fish game object

    Vector3 misalignAnimals = new Vector3(0, 0, 5); // Vector representing the misalignment offset for animals
    Vector3 misalignVertical = new Vector3(0, 1, 0); // Vector representing the vertical misalignment offset

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitMisalign()); // Start a coroutine to wait and misalign the animals
    }

    IEnumerator waitMisalign()
    {
        yield return new WaitForSeconds(1); // Wait for 1 second before misaligning the animals

        birds.transform.localPosition += misalignAnimals; // Misalign the birds by adding the misalignment offset
        fish.transform.localPosition -= misalignAnimals; // Misalign the fish by subtracting the misalignment offset
        birds.transform.localPosition -= misalignVertical; // Vertically misalign the birds
    }

    public void alignBirdsFish()
    {
        birds.transform.localPosition += misalignVertical; // Align the birds vertically by adding the vertical misalignment offset
    }
}
