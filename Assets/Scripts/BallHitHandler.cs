using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();
            collision.gameObject.SetActive(false);

            puzzleFinished.Play();
            PlayerPrefs.SetInt(puzzleName, 1);

        }
    }

    [SerializeField] private string puzzleName;
    [SerializeField] AudioSource puzzleFinished;

}
