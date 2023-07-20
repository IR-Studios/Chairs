using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIstage { Looking, Stalking, Hunting }
public class ChairAI : MonoBehaviour
{
    public AIstage mode;
    public Transform player;               // Reference to the player object
    public Camera playerCamera;            // Reference to the player's camera
    public GameObject destroyableChair;
    public GameObject chairModel;

    [Header("Chair Stats")]
    public int health;
    public int explosionForce;

    void Update()
    {
        // Check if the entity can see the player and the player's camera can't see the entity
        if (!IsVisibleToCamera())
        {
            // Look at the player object
            Vector3 direction = player.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }

    bool CanSeePlayer()
    {
        // Check if the entity can see the player object
        Vector3 playerDirection = player.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, playerDirection, out hit))
        {
            if (hit.transform == player)
            {
                // Player object is within line of sight
                return true;
            }
        }

        // Player object is not visible to the entity
        return false;
    }

    bool IsVisibleToCamera()
    {
        // Check if the entity is visible to the player's camera
        Vector3 entityViewportPoint = playerCamera.WorldToViewportPoint(transform.position);
        return (entityViewportPoint.x >= 0 && entityViewportPoint.x <= 1 &&
                entityViewportPoint.y >= 0 && entityViewportPoint.y <= 1 &&
                entityViewportPoint.z > 0);
    }

    public void onDeath(Transform shootpoint, float minExplosionForce, float maxExplosionForce)
        {
    chairModel.SetActive(false);
    health = 0;

    GameObject deathChair = Instantiate(destroyableChair, this.gameObject.transform.position, Quaternion.identity);
    Rigidbody[] childRigidbodies = deathChair.GetComponentsInChildren<Rigidbody>();

    float maxDistance = Vector3.Distance(transform.position, shootpoint.position);

    foreach (Rigidbody rb in childRigidbodies)
    {
        Vector3 explosionDirection = rb.transform.position - shootpoint.position;
        float distance = Vector3.Distance(rb.transform.position, shootpoint.position);
        float t = Mathf.InverseLerp(0f, maxDistance, distance); // Normalize the distance between 0 and 1

        // Interpolate the explosion force between maxExplosionForce and minExplosionForce (reversed) based on the distance
        float explosionForce = Mathf.Lerp(maxExplosionForce, minExplosionForce, t);
        rb.AddForce(explosionDirection.normalized * explosionForce, ForceMode.Impulse);
        Debug.Log("Explosion Force: " + explosionForce);
    }

    BoxCollider collider = GetComponent<BoxCollider>();
    collider.enabled = false;
}

}
    
