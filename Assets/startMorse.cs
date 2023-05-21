using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMorse : MonoBehaviour
{
    [SerializeField] GameObject morseParent; // Serialized field for the parent game object of the Morse code objects

    [SerializeField] Collider leftHand; // Serialized field for the collider representing the left hand
    [SerializeField] Collider rightHand; // Serialized field for the collider representing the right hand

    [SerializeField] AudioSource crowCaw; // Serialized field for the crow caw sound audio source
    [SerializeField] AudioSource pling; // Serialized field for the pling sound audio source

    [SerializeField] GameObject arrowObj; // Serialized field for the arrow game object

    Vector3 moveMorse = new Vector3(0, -0.05f, 0); // Vector representing the movement offset for the Morse code objects
    Vector3 startPos = Vector3.zero; // Starting position of the morseParent game object

    public List<GameObject> morses; // List of Morse code game objects

    public bool startMovement = false; // Flag indicating if the movement of Morse code objects should start
    public int currentNum = 0; // Current index of the Morse code object being displayed

    private void Start()
    {
        startPos = morseParent.transform.localPosition; // Store the starting position of the morseParent game object
    }

    // Update is called once per frame
    void Update()
    {
        if (startMovement)
        {
            morseParent.transform.localPosition += moveMorse; // Move the morseParent game object based on the moveMorse offset
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col == leftHand || col == rightHand) // Check if the collider belongs to the left hand or the right hand
        {
            startMovement = true; // Start the movement of Morse code objects
            morseParent.transform.localPosition = startPos; // Reset the position of the morseParent game object

            for (int i = 0; i < morses.Count; i++)
            {
                morses[i].SetActive(false); // Deactivate all Morse code game objects
            }

            morses[currentNum++].SetActive(true); // Activate the Morse code game object at the current index

            arrowObj.transform.position = arrowObj.transform.parent.Find("pos" + currentNum).GetComponent<Transform>().position; // Move the arrow game object to the corresponding position

            if (currentNum >= morses.Count)
                currentNum = 0; // Reset the currentNum index if it exceeds the number of Morse code objects

            crowCaw.Play(); // Play the crow caw sound
            StartCoroutine(waitPling()); // Start a coroutine to wait and play the pling sound
        }
    }

    IEnumerator waitPling()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds

        pling.Play(); // Play the pling sound
    }
}
