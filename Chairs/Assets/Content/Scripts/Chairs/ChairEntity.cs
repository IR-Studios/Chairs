using UnityEngine;

public class ChairEntity : MonoBehaviour
{
    public bool isActive = true; // Toggle whether the chair is active or not

    public float moveSpeed = 0.5f; // Speed at which the chair moves
    public float moveInterval = 1f; // Time interval between random movement increments

    private Transform playerTransform;
    private Vector3 targetPosition;

    private bool isMoving = false;
    private float moveTimer = 0f;

    private AudioSource audioSource;
    public AudioClip[] chairNoises; // Add audio clips for the chair's noises

    private Collider triggerCollider;
    private Renderer chairRenderer;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        triggerCollider = GetComponent<Collider>();
        chairRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!isActive)
            return;

        if (chairRenderer.isVisible)
        {   
            print("I can see you");
            isMoving = false;
        }
        else
        {
            if (!isMoving)
            {
                moveTimer += Time.deltaTime;
                if (moveTimer >= moveInterval)
                {
                    isMoving = true;
                    moveTimer = 0f;
                    targetPosition = GetRandomPosition();
                }
            }
            else
            {
                MoveTowardsTarget();
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(playerTransform.position.x - 1f, playerTransform.position.x + 1f);
        float randomZ = Random.Range(playerTransform.position.z - 1f, playerTransform.position.z + 1f);
        Vector3 randomPosition = new Vector3(randomX, transform.position.y, randomZ);
        return randomPosition;
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add code to kill the player here
        }
    }

    // Add any additional audio-related methods or functionalities here
    // For example, you can play chair noises randomly or based on certain events

}
