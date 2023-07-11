using System.Collections;
using UnityEngine;

public class PointLightFlicker : MonoBehaviour
{
    public float minIntensity = 0.2f;      // Minimum intensity of the flickering
    public float maxIntensity = 1.0f;      // Maximum intensity of the flickering
    public float flickerSpeed = 5.0f;      // Speed at which the flickering occurs

    public Light[] pointLights;           // Array to hold the reference to the point lights
    private float[] originalIntensities;   // Array to store the original intensities of the lights

    public bool flickering = true;

    void Start()
    {
        // Get all the point lights attached to the GameObject
        pointLights = GetComponentsInChildren<Light>();

        // Store the original intensities of the lights
        originalIntensities = new float[pointLights.Length];
        for (int i = 0; i < pointLights.Length; i++)
        {
            originalIntensities[i] = pointLights[i].intensity;
        }

        // Start the flickering coroutine for each light
        foreach (Light light in pointLights)
        {
            StartCoroutine(FlickerLight(light));
        }
    }

    public IEnumerator FlickerLight(Light light)
    {
        while (flickering)
        {
            // Randomly set the intensity of the light between the min and max values
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            light.intensity = randomIntensity;

            // Wait for a random duration before changing the intensity again
            float randomDuration = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(randomDuration / flickerSpeed);

            // Reset the intensity to the original value
            light.intensity = originalIntensities[GetLightIndex(light)];

            // Wait for a random duration before starting the next flicker
            float flickerDelay = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(flickerDelay);
        }
    }

    int GetLightIndex(Light light)
    {
        for (int i = 0; i < pointLights.Length; i++)
        {
            if (pointLights[i] == light)
            {
                return i;
            }
        }
        return -1;
    }
}

