using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door Variables")]
    public bool isLocked; // Whether the door is locked
    public bool isBlocked; // Whether the door is blocked
    public bool requiresKey; //Whether the door requires a key to unlock
    [SerializeField] private bool isOpen = false; // Whether the door is currently open
    private bool isInteracting = false; // Whether the player is currently interacting with the door
    private Quaternion initialRotation; // Initial rotation of the door
    private Quaternion openRotation; // Rotation when the door is fully open
    public float openAngle = -100f; // Angle by which the door opens

    private float initialRotationY;

    private void Start()
    {
        initialRotation = transform.rotation;
        openRotation = Quaternion.Euler(0f, openAngle, 0f);

        initialRotationY = transform.localEulerAngles.y;
        Debug.Log(initialRotationY);
    }

    private void Update()
    {
        // Pushing door open
        pushDoor();
        //interactDoor();
    }

    void pushDoor()
    {
        RaycastHit hit;
        float maxDistance = 1f;
        float doorRotateSpeed = 30f;
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
    {
        Door doorScript;

        if (hit.transform.CompareTag("DoorFront"))
        {
            doorScript = hit.transform.GetComponentInParent<Door>();

            if (!doorScript.isLocked)
            {
                float currentRotation = hit.transform.parent.localEulerAngles.y;
                float targetRotation = initialRotationY - 89;
                Debug.Log(targetRotation);
                Debug.Log("Current Rotation: " + currentRotation);

                if (currentRotation > targetRotation)
                {
                    hit.transform.parent.Rotate(Vector3.up * -doorRotateSpeed * Time.deltaTime);
                }
            }
        }

        if (hit.transform.CompareTag("DoorBack"))
        {
            doorScript = hit.transform.GetComponentInParent<Door>();

            if (!doorScript.isLocked)
            {
                float currentRotation = hit.transform.parent.localEulerAngles.y;
                float targetRotation = initialRotationY + 89;

                if (currentRotation < targetRotation)
                {
                    hit.transform.parent.Rotate(Vector3.up * doorRotateSpeed * Time.deltaTime);
                }
            }
        }
    }
    }

    void interactDoor()
    {
        RaycastHit hit;
        float maxDistance = 3f;
        float doorRotateSpeed = 30f;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            Door doorScript;

            if (hit.transform.CompareTag("DoorFront"))
            {
                doorScript = hit.transform.GetComponentInParent<Door>();

                if (Input.GetKeyDown(KeyCode.E) && !doorScript.isLocked)
                {
                    StartCoroutine(RotateDoor(hit.transform.parent, 0f, doorRotateSpeed));
                    doorScript.isOpen = !doorScript.isOpen;
                }
            }

            if (hit.transform.CompareTag("DoorBack"))
            {
                doorScript = hit.transform.GetComponentInParent<Door>();

                if (Input.GetKeyDown(KeyCode.E) && !doorScript.isLocked)
                {
                    StartCoroutine(RotateDoor(hit.transform.parent, 180f, doorRotateSpeed));
                    doorScript.isOpen = !doorScript.isOpen;
                }
            }
        }
    }

    IEnumerator RotateDoor(Transform doorTransform, float targetRotation, float rotateSpeed)
    {
        Quaternion initialRotation = doorTransform.rotation;
        Quaternion targetQuaternion = Quaternion.Euler(0f, doorTransform.eulerAngles.y + targetRotation, 0f);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * rotateSpeed;
            doorTransform.rotation = Quaternion.Slerp(initialRotation, targetQuaternion, elapsedTime);
            yield return null;
        }
    }
}
