using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdTrigger : MonoBehaviour
{
    public GameObject Chair;
    public Transform moveLocation;
    public AudioSource audioS;
    float duration = 1f; // Time taken to move the Chair

    bool isEntered;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            if (!isEntered) 
            {
                 StartCoroutine(ChairMovesTowardYou());
            }
           
        }
    }

    IEnumerator ChairMovesTowardYou() 
    {
        isEntered = true;
        audioS.Play();

        Vector3 initialPosition = Chair.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Chair.transform.position = Vector3.Lerp(initialPosition, moveLocation.position, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        Chair.SetActive(false);
    }
}
