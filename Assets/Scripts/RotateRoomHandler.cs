using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoomHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateRoom(Quaternion rotate)
    {
        transform.rotation = rotate;
    }
}
