using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnHome : MonoBehaviour
{
    [SerializeField] Collider mainPlayer;
    public int sceneNum = 1;

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if(mainPlayer.transform.name == col.transform.name)
        {
            SceneManager.LoadScene(sceneNum);
        }
    }
}
