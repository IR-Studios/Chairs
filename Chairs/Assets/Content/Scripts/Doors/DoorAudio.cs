using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class DoorAudio : MonoBehaviour
{
    private HingeJoint doorHinge;
    private AudioSource audioSource;

    [Header("Audio")]
    public AudioClip doorOpeningClip;
    public AudioClip doorClosedClip;
    public float doorOpeningVolume = 0.5f;
    public float doorClosedVolume = 1f;

    private bool isDoorOpen = false;

    private void Start()
    {
        doorHinge = GetComponent<HingeJoint>();
        audioSource = GetComponent<AudioSource>();

        // Ensure the AudioSource is configured correctly
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f; // For 3D spatial audio

        audioSource.clip = doorOpeningClip;
        audioSource.volume = doorOpeningVolume;

        isDoorOpen = false;
    }

    private void Update()
    {
        // Check if the door is opening or closing based on the door hinge angle
        float currentDoorAngle = doorHinge.angle;

        if ((currentDoorAngle > 2f && currentDoorAngle < 180f) || (currentDoorAngle < -2f && currentDoorAngle > -180f))
        {
            // Door is opening
            if (!isDoorOpen)
            {
                PlayDoorOpeningSound();
                isDoorOpen = true;
            }
        }
        else if ((currentDoorAngle < 2f && currentDoorAngle > 0f) || (currentDoorAngle > 358f && currentDoorAngle < 360f)
                 || (currentDoorAngle > -2f && currentDoorAngle < 0f) || (currentDoorAngle < -358f && currentDoorAngle > -360f))
        {
            // Door is closed
            if (isDoorOpen)
            {
                PlayDoorClosedSound();
                isDoorOpen = false;
            }
        }
    }

    private void PlayDoorOpeningSound()
    {
        if (doorOpeningClip != null)
        {
            audioSource.Stop();
            audioSource.clip = doorOpeningClip;
            audioSource.Play();
        }
    }

    private void PlayDoorClosedSound()
    {
        if (doorClosedClip != null)
        {
            audioSource.Stop();
            audioSource.clip = doorClosedClip;
            audioSource.volume = doorClosedVolume;
            audioSource.Play();
        }
    }
}







