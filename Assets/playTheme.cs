using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTheme : MonoBehaviour
{
    [SerializeField] AudioSource firstTheme; // Serialized field for the first theme audio source
    [SerializeField] AudioSource secondTheme; // Serialized field for the second theme audio source
    [SerializeField] AudioSource thirdTheme; // Serialized field for the third theme audio source

    [SerializeField] AudioSource snap; // Serialized field for the snap sound audio source
    [SerializeField] AudioSource bang; // Serialized field for the bang sound audio source
    [SerializeField] AudioSource slam; // Serialized field for the slam sound audio source

    [SerializeField] GameObject chandelier; // Serialized field for the chandelier game object
    [SerializeField] GameObject chandelierTeleport; // Serialized field for the chandelier teleportation target game object

    [SerializeField] GameObject piano; // Serialized field for the intact piano game object
    [SerializeField] GameObject brokenPiano; // Serialized field for the broken piano game object

    [SerializeField] GameObject lobbyLight; // Serialized field for the lobby light game object

    [SerializeField] GameObject signParent; // Serialized field for the sign parent game object

    private int themeScore; // Variable to store the theme score
    private int flickerFactor = 10; // Factor determining the flickering rate of the lobby light
    private bool stopFlickering = false; // Flag to stop the flickering effect
    [SerializeField] public bool noFlickering = false; // Serialized field to disable flickering

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the theme score based on puzzle completion values stored in PlayerPrefs
        themeScore += PlayerPrefs.GetInt("morsePuzzle");
        themeScore += PlayerPrefs.GetInt("waterfallPuzzle");
        themeScore += PlayerPrefs.GetInt("alignPuzzle");

        switch (themeScore)
        {
            case 0:
                firstTheme.Play(); // Play the first theme audio
                break;
            case 1:
                secondTheme.Play(); // Play the second theme audio
                break;
            case 2:
                thirdTheme.Play(); // Play the third theme audio
                break;
            case 3:
                thirdTheme.Play(); // Play the third theme audio
                if (Convert.ToBoolean(PlayerPrefs.GetInt("isBroken")))
                    setBrokenPiano(); // Set the broken piano state if it's previously broken
                else
                    breakPiano(); // Break the piano if it's intact
                break;
        }

        flickerFactor -= (themeScore * 2); // Adjust the flicker factor based on the theme score
    }

    private void Update()
    {
        if (!stopFlickering && !noFlickering) // Check if flickering is not disabled
            lobbyLight.SetActive(Convert.ToBoolean(UnityEngine.Random.Range(0, flickerFactor))); // Randomly activate or deactivate the lobby light
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == chandelier) // Check if the collider belongs to the chandelier
        {
            piano.SetActive(false); // Deactivate the intact piano
            brokenPiano.SetActive(true); // Activate the broken piano
            chandelier.GetComponent<Rigidbody>().isKinematic = true; // Disable the chandelier's physics simulation
            chandelier.transform.position = chandelierTeleport.transform.position; // Teleport the chandelier to the designated position
            chandelier.transform.rotation = chandelierTeleport.transform.rotation; // Set the rotation of the chandelier to match the teleportation target
            bang.Play(); // Play the bang sound
            slam.Play(); // Play the slam sound
            stopFlickering = true; // Stop the flickering effect
            lobbyLight.SetActive(false); // Deactivate the lobby light
            PlayerPrefs.SetInt("isBroken", 1); // Set the "isBroken" PlayerPrefs value to 1
            signParent.SetActive(false); // Deactivate the sign parent
        }
    }

    void breakPiano()
    {
        snap.Play(); // Play the snap sound
        chandelier.GetComponent<Rigidbody>().useGravity = true; // Enable gravity for the chandelier
    }

    void setBrokenPiano()
    {
        piano.SetActive(false); // Deactivate the intact piano
        chandelier.SetActive(false); // Deactivate the chandelier
    }
}
