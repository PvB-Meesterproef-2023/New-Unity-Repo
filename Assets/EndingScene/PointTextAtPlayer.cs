using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTextAtPlayer : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] GameObject playerObject;


    private void Start()
    {

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found. Make sure to set the appropriate tag or assign the player object manually.");
        }
    }

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Calculate the direction from the text to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Rotate the text to face the player
            transform.rotation = Quaternion.LookRotation(-directionToPlayer);
        }
    }
}
