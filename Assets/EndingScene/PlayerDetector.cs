using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] GameObject playerObject; // Serialized field for the player object
    [SerializeField] GameObject scareObject; // Serialized field for the scare object
    [SerializeField] GameObject UIPanel; // Serialized field for the UI panel
    [SerializeField] AudioSource audio; // Serialized field for the audio source

    private int isScared = 0; // Flag to track if the scare has occurred

    private void Start()
    {
        initialPosition = scareObject.transform.position; // Store the initial position of the scare object

        // Calculate the target position based on the target object's position
        targetPosition = target.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject == playerObject && isScared == 0)
        {
            Debug.Log("Player detected!");
            // Move the object in steps of 0.5 towards the player
            scareObject.transform.position = Vector3.MoveTowards(scareObject.transform.position, playerObject.transform.position, 0.5f);
            StartCoroutine(MoveCoroutine()); // Start the coroutine to move the scare object smoothly
            audio.Play(); // Play the audio
            isScared++;
        }
    }

    private void Update()
    {
        // If the player pressed the 'T' key and the scare hasn't occurred yet
        if (Input.GetKeyDown(KeyCode.T) && isScared == 0)
        {
            Debug.Log("Player detected!");
            // Move the object in steps of 0.5 towards the player
            scareObject.transform.position = Vector3.MoveTowards(scareObject.transform.position, playerObject.transform.position, 0.5f);
            StartCoroutine(MoveCoroutine()); // Start the coroutine to move the scare object smoothly
            audio.Play(); // Play the audio
            isScared++;
        }
    }

    public Transform target; // Target transform for smooth movement
    public float movementSpeed = 0.5f; // Speed of movement
    public float duration = 1f; // Duration of movement

    private Vector3 initialPosition; // Initial position of the scare object
    private Vector3 targetPosition; // Target position for movement

    private System.Collections.IEnumerator MoveCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the normalized time (0 to 1) based on the elapsed time and duration
            float normalizedTime = elapsedTime / duration;

            // Calculate the current position using Lerp
            Vector3 currentPosition = Vector3.Lerp(initialPosition, targetPosition, normalizedTime);

            // Move the object towards the target position
            scareObject.transform.position = currentPosition;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Movement completed
        Debug.Log("Movement completed!");
        UIPanel.SetActive(true); // Activate the UI panel
    }

}
