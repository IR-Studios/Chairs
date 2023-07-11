using UnityEngine;
using System.Collections;

public class SpotlightFlicker : MonoBehaviour
{
    public Light spotlight;                  // Reference to the spotlight component
    public float minIntensity = 0.2f;        // Minimum intensity of the flickering
    public float maxIntensity = 1.0f;        // Maximum intensity of the flickering
    public float flickerSpeed = 5.0f;        // Speed at which the flickering occurs

    private float originalIntensity;         // Original intensity of the spotlight

    void Start()
    {
        originalIntensity = spotlight.intensity;
        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        while (true)
        {
            // Randomly set the intensity of the spotlight between the min and max values
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            spotlight.intensity = randomIntensity;

            // Wait for a random duration before changing the intensity again
            float randomDuration = Random.Range(0.05f, 0.2f);
            yield return new WaitForSeconds(randomDuration / flickerSpeed);

            // Reset the intensity to the original value
            spotlight.intensity = originalIntensity;

            // Wait for a random duration before starting the next flicker
            float flickerDelay = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(flickerDelay);
        }
    }
}
