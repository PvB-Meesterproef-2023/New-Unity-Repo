using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdButton : MonoBehaviour
{
    [SerializeField] Collider pokeColliderLeft;
    [SerializeField] Collider pokeColliderRight;
    [SerializeField] GameObject bird;
    [SerializeField] GameObject nextPuzzle;
    [SerializeField] AudioSource errorSFX;

    bool isAligned = false;
    public bool fishAligned = false;
    public bool birdAligned = false;

    public void OnTriggerEnter(Collider col)
    {
        if (birdAligned && fishAligned && !isAligned)
        {
            isAligned = true;
            gameObject.transform.parent.GetComponent<birdFishAlign>().alignBirdsFish();
            nextPuzzle.SetActive(true);
        }
        else if(!isAligned) errorSFX.Play();
    }
}
