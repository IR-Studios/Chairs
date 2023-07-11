using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Numpad : MonoBehaviour
{
    [Header("Keypad Information")]
    public int code;
    public bool isPowered;
    
    public int num1, num2, num3, num4;
    [HideInInspector]
    public int currentNum;

    [Header("Light Attributes")]
    public float blinkInterval = 0.2f;      // Interval at which the light blinks when the code is incorrect
    public int blinkCount = 5;               // Number of times the light blinks

    [Header("Numbers")]
    public GameObject[] numbers;
    public Material offline;
    public Material online;

    [Header("References")]
    public TextMeshPro DisplayText;
    public DoorSystem doorToUnlock;
    public Light numpadLight;
    private Coroutine blinkCoroutine;       // Reference to the coroutine for blinking

    public AudioSource beep;


    public void Start() 
    {
        DisplayText.text = "";
        if (doorToUnlock.doorLocked) 
        {
            numpadLight.color = Color.red;
        }
    }

    void Update() 
    {
        if (!isPowered) 
        {
            numpadLight.enabled = false;
            foreach(GameObject N in numbers) 
            {
                Renderer renderer = N.GetComponent<Renderer>();
                if (renderer != null) 
                {
                    renderer.material = offline;
                }
            }
        } else if (isPowered) {
            numpadLight.enabled = true;
             foreach(GameObject N in numbers) 
            {
                Renderer renderer = N.GetComponent<Renderer>();
                if (renderer != null) 
                {
                    renderer.material = online;
                }
            }
        }
    }

    public void checkInput() 
    {
        string correctCode = code.ToString();
        string inputtedCode = num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString();

        if (string.Equals(correctCode, inputtedCode)) 
        {
            doorToUnlock.doorLocked = false;
            doorToUnlock.Audio.Play();
            numpadLight.color = Color.green;
        } else 
        {
            currentNum = 0;
            DisplayText.text = "";

            //make point light blink rapidly
            
            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);
            }

            blinkCoroutine = StartCoroutine(BlinkLight());
        }
    }
    IEnumerator BlinkLight()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            numpadLight.intensity = 0;
            yield return new WaitForSeconds(blinkInterval);

            numpadLight.intensity = 0.1f;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
