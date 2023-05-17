using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject scareObject;
    [SerializeField] GameObject UIPanel;
    [SerializeField] AudioSource audio;

    private int isScared = 0;

    private void Start()
    {
        initialPosition = scareObject.transform.position;

        // Calculate the target position based on the target object's position
        targetPosition = target.position;
    }


    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject == playerObject && isScared == 0)
        {
            Debug.Log("Player detected!");
            // move the object in steps of .5 to the player
            scareObject.transform.position = Vector3.MoveTowards(scareObject.transform.position, playerObject.transform.position, 0.5f);
            StartCoroutine(MoveCoroutine());
            audio.Play();
            isScared++;
        }
    }

    private void Update()
    {
        // if player pressed t 
        if (Input.GetKeyDown(KeyCode.T) && isScared == 0)
        {
            Debug.Log("Player detected!");
            // move the object in steps of .5 to the player
            scareObject.transform.position = Vector3.MoveTowards(scareObject.transform.position, playerObject.transform.position, 0.5f);
            StartCoroutine(MoveCoroutine());
            audio.Play();
            isScared++;
        }

    }


    public Transform target;
    public float movementSpeed = 0.5f;
    public float duration = 1f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;


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
        UIPanel.SetActive(true);
    }
}
