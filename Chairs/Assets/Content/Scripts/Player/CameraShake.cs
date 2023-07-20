using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Shake Settings")]
    public float shakeDuration = 0.3f;
    public float shakeIntensity = 0.1f;

    private Transform cameraTransform;
    private Vector3 originalCameraPosition;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    public void Shake()
    {
        originalCameraPosition = cameraTransform.localPosition;
        InvokeRepeating("StartShake", 0f, 0.01f);
        Invoke("StopShake", shakeDuration);
    }

    private void StartShake()
    {
        float shakeX = Random.Range(-1f, 1f) * shakeIntensity;
        float shakeY = Random.Range(-1f, 1f) * shakeIntensity;
        cameraTransform.localPosition = originalCameraPosition + new Vector3(shakeX, shakeY, 0f);
    }

    private void StopShake()
    {
        CancelInvoke("StartShake");
        cameraTransform.localPosition = originalCameraPosition;
    }
}
