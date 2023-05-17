using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtFlicker : MonoBehaviour
{
    public Renderer objectRenderer;
    public float minFlickerTime = 0.5f;
    public float maxFlickerTime = 2f;
    public Texture[] creepyTextures;

    private void Start()
    {
        // Start the flickering coroutine
        StartCoroutine(FlickerCoroutine());
    }

    private IEnumerator FlickerCoroutine()
    {
        while (true)
        {
            // Generate a random flicker time between minFlickerTime and maxFlickerTime
            float flickerTime = Random.Range(minFlickerTime, maxFlickerTime);

            // Wait for the random flicker time
            yield return new WaitForSeconds(flickerTime);


            // Randomly change the texture
            if (creepyTextures.Length > 0)
            {
                int randomTextureIndex = Random.Range(0, creepyTextures.Length);
                objectRenderer.material.mainTexture = creepyTextures[randomTextureIndex];
            }
        }
    }
}
