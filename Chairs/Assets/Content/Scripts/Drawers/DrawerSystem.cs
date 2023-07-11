using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerSystem : MonoBehaviour
{
    public bool isLocked; //is the drawer locked?
  public bool isOpen = false;            // Indicates whether the drawer is open or closed
    public float openDistance = 1f;        // Distance the drawer moves when opening
    public float openDuration = 1f;        // Time taken to open/close the drawer

    private Vector3 closedPosition;        // Initial position of the drawer
    private Vector3 openPosition;          // Target position when the drawer is open
    private Vector3 targetPosition;        // Current target position of the drawer
    private float currentLerpTime = 0f;    // Current lerp time for opening/closing
    private bool isAnimating = false;      // Flag to indicate if the drawer is currently animating

    AudioSource drawerSound;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + (transform.forward * openDistance);

        drawerSound = gameObject.AddComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>("Audio/drawerOpen");
        drawerSound.clip = clip;

        drawerSound.loop = false;
        drawerSound.playOnAwake = false;
        drawerSound.spatialBlend = 1f;
        drawerSound.reverbZoneMix = 1.05f;
        

    }

    private void Update()
    {
        if (isAnimating)
        {
            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > openDuration)
            {
                currentLerpTime = openDuration;
                isAnimating = false;
            }

            float t = currentLerpTime / openDuration;
            transform.position = Vector3.Lerp(transform.position, targetPosition, t);
        }
    }

    public void Interact()
    {
        if (!isAnimating)
        {
            if (isOpen)
            {
                CloseDrawer();
            }
            else
            {
                OpenDrawer();
            }
        }
    }

    private void OpenDrawer()
    {
        drawerSound.Play();
        targetPosition = openPosition;
        currentLerpTime = 0f;
        isAnimating = true;
        isOpen = true;
    }

    private void CloseDrawer()
    {
        drawerSound.Play();
        targetPosition = closedPosition;
        currentLerpTime = 0f;
        isAnimating = true;
        isOpen = false;
    }
}
