using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChairChase : MonoBehaviour
{
    public GameObject chair;
    public AudioSource soundEffect;
    public AudioSource intenseMusic;
    public Transform movementLocation1, movementLocation2;
    bool isAtLocation1;
    bool hitPlayer;
    public float duration = 1.5f;
    public float secondDuration;

    [Header("References")]
    public PointLightFlicker PF;
    bool isEntered = false;

    void Start() 
    {
        foreach (Light L in PF.pointLights) 
                {   
                    L.enabled = false;
                }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            if (!isEntered) 
            {
                // foreach (Light L in PF.pointLights) 
                // {   
                //     L.enabled = true;
                // }
                // PF.flickering = true;
                StartCoroutine(StartChase());
                // foreach (Light light in PF.pointLights)
                // {
                //  StartCoroutine(PF.FlickerLight(light));
                // }
            }
        }
    }

    IEnumerator StartChase()
{
    chair.SetActive(true);
    soundEffect.Play();

    yield return new WaitForSeconds(2f);

    intenseMusic.Play();

    // Start Chase
    Vector3 initialPosition = chair.transform.position;
    float elapsedTime = 0f;

    while (elapsedTime < duration && !hitPlayer && !isAtLocation1)
    {
        chair.transform.position = Vector3.Lerp(initialPosition, movementLocation1.position, elapsedTime / duration);
        elapsedTime += Time.deltaTime;
        if (chair.transform.position == movementLocation1.position) isAtLocation1 = true;

        yield return null;
    }

    float rotateDuration = 1f;

    Quaternion targetRotation = Quaternion.Euler(0f, 90f, 0f);
    float rotationSpeed = 90f / rotateDuration;

    elapsedTime = 0f;
    initialPosition = chair.transform.position;

    // Rotate the chair first
    while (Quaternion.Angle(chair.transform.rotation, targetRotation) > 0.1f)
    {
        chair.transform.rotation = Quaternion.RotateTowards(chair.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        yield return null;
    }

    yield return new WaitForSeconds(1f); // Delay before moving towards the second location

    // Chair chase second location
    elapsedTime = 0f;
    while (elapsedTime < secondDuration && !hitPlayer)
    {
        chair.transform.position = Vector3.Lerp(initialPosition, movementLocation2.position, elapsedTime / secondDuration);
        elapsedTime += Time.deltaTime;

        yield return null;
    }
}
}
