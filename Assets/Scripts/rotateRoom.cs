using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRoom : MonoBehaviour
{
    [SerializeField] GameObject mainPlayer;
    [SerializeField] GameObject theRoom;
    [SerializeField] GameObject tpZone;

    public bool turnX = false;
    public bool turnY = false;
    public bool turnZ = false;
    public bool turnXNegative;
    public bool turnYNegative;
    public bool turnZNegative;

    bool waitRoomTurn = false;

    bool hasTurned = false;

    Vector3 rotateDegree = new Vector3(0, 0, 0);


    public float rotationSpeed = 1.0f;
    public float targetRotation = 90.0f;

    private Quaternion startingRotation;
    private Quaternion targetQuaternion;

    private void Start()
    {
        if (turnX) rotateDegree.x = 90;
        if (turnY) rotateDegree.y = 90;
        if (turnZ) rotateDegree.z = 90;

        if (turnXNegative) rotateDegree.x = -rotateDegree.z;
        if (turnYNegative) rotateDegree.y = -rotateDegree.z;
        if (turnZNegative) rotateDegree.z = -rotateDegree.z;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == mainPlayer.name)
        {
            theRoom.transform.Rotate(rotateDegree);
            rotateDegree = -rotateDegree;
            mainPlayer.transform.position = tpZone.transform.position;
        }
    }
}
