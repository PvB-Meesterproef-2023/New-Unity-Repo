using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTheme : MonoBehaviour
{
    [SerializeField] AudioSource firstTheme;
    [SerializeField] AudioSource secondTheme;
    [SerializeField] AudioSource thirdTheme;

    [SerializeField] AudioSource snap;
    [SerializeField] AudioSource bang;
    [SerializeField] AudioSource slam;

    [SerializeField] GameObject chandelier;
    [SerializeField] GameObject chandelierTeleport;

    [SerializeField] GameObject piano;
    [SerializeField] GameObject brokenPiano;

    [SerializeField] GameObject lobbyLight;

    [SerializeField] GameObject signParent;

    private int themeScore;
    private int flickerFactor = 10;
    private bool stopFlickering = false;

    // Start is called before the first frame update
    void Start()
    {
        themeScore += PlayerPrefs.GetInt("morsePuzzle");
        themeScore += PlayerPrefs.GetInt("waterfallPuzzle");
        themeScore += PlayerPrefs.GetInt("alignPuzzle");
        breakPiano();
        switch (themeScore)
        {
            case 0:
                firstTheme.Play();
                break;
            case 1:
                secondTheme.Play();
                break;
            case 2:
                thirdTheme.Play();
                break;
            case 3:
                thirdTheme.Play();
                //if (Convert.ToBoolean(PlayerPrefs.GetInt("isBroken")))
                //    setBrokenPiano();
                //else
                //    breakPiano();
                break;
        }

        flickerFactor -= (themeScore * 2);
    }

    private void Update()
    {
    //    if(!stopFlickering)
    //        lobbyLight.SetActive(Convert.ToBoolean(UnityEngine.Random.Range(0, flickerFactor)));
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.name == chandelier.name)
        {
            piano.SetActive(false);
            brokenPiano.SetActive(true);
            chandelier.GetComponent<Rigidbody>().isKinematic = true;
            chandelier.transform.position = chandelierTeleport.transform.position;
            chandelier.transform.rotation = chandelierTeleport.transform.rotation;
            bang.Play();
            slam.Play();
            stopFlickering = true;
            lobbyLight.SetActive(false);
            PlayerPrefs.SetInt("isBroken", 1);
            signParent.SetActive(false);
        }
    }

    void breakPiano()
    {
        snap.Play();
        chandelier.GetComponent<Rigidbody>().useGravity = true;
    }

    void setBrokenPiano()
    {
        piano.SetActive(false);
        chandelier.SetActive(false);
    }
}
