using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRoom : MonoBehaviour
{
    // Script is meant to be a more global script, to be used on multiple 

    // Reference to the main player object
    [SerializeField] GameObject mainPlayer;

    // Reference to the room object to rotate
    [SerializeField] GameObject theRoom;

    // Reference to the teleport zone object
    [SerializeField] GameObject tpZone;

    // Flags to determine the rotation axis and direction
    public bool turnX = false;
    public bool turnY = false;
    public bool turnZ = false;
    public bool turnXNegative;
    public bool turnYNegative;
    public bool turnZNegative;

    bool waitRoomTurn = false;

    bool hasTurned = false;

    // Stores the degree of rotation for each axis
    Vector3 rotateDegree = new Vector3(0, 0, 0);

    // Rotation speed and target rotation angle
    public float rotationSpeed = 1.0f;
    public float targetRotation = 90.0f;

    private Quaternion startingRotation;
    private Quaternion targetQuaternion;

    private void Start()
    {
        // Set the rotateDegree based on the specified turn values

        // If turnX is true, rotateDegree.x is set to 90
        if (turnX) rotateDegree.x = 90;

        // If turnY is true, rotateDegree.y is set to 90
        if (turnY) rotateDegree.y = 90;

        // If turnZ is true, rotateDegree.z is set to 90
        if (turnZ) rotateDegree.z = 90;

        // If turnXNegative is true, rotateDegree.x is set to the negation of rotateDegree.z
        if (turnXNegative) rotateDegree.x = -rotateDegree.z;

        // If turnYNegative is true, rotateDegree.y is set to the negation of rotateDegree.z
        if (turnYNegative) rotateDegree.y = -rotateDegree.z;

        // If turnZNegative is true, rotateDegree.z is set to the negation of rotateDegree.z
        if (turnZNegative) rotateDegree.z = -rotateDegree.z;
    }

    private void OnTriggerEnter(Collider col)
    {
        // Check if the collider that entered is the mainPlayer collider
        if (col.name == mainPlayer.name)
        {
            // Rotate the room by the specified rotateDegree
            theRoom.transform.Rotate(rotateDegree);

            // Reverse the rotateDegree for the next trigger
            rotateDegree = -rotateDegree;

            // Move the mainPlayer to the tpZone position
            mainPlayer.transform.position = tpZone.transform.position;
        }
    }

}
