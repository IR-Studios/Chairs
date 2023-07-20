using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameFade : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI text;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            FirstPersonAIO player = other.GetComponent<FirstPersonAIO>();
            

            StartCoroutine(FadeGameOut(player));
        }
    }

    IEnumerator FadeGameOut(FirstPersonAIO player) 
    {
        float textAlpha = 0f;
        float backgroundAlpha = 0f;

        Color textFadeColor = text.color;

        Color backgroundFadeColor = background.color;

        float fadeDuration = 2f;
        float backgroundFadeDuration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
        
            // Calculate the normalized alpha value based on the elapsed time
            float normalizedTime = Mathf.Clamp01(elapsedTime / backgroundFadeDuration);

            backgroundFadeColor.a = Mathf.Lerp(backgroundAlpha, 1f, normalizedTime);
            background.color = backgroundFadeColor;

            yield return null;
        }
        player.controllerPauseState = true;

        yield return new WaitForSeconds(1f);

        elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
        
            // Calculate the normalized alpha value based on the elapsed time
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);

            textFadeColor.a = Mathf.Lerp(textAlpha, 1f, normalizedTime);
            text.color = textFadeColor;

            yield return null;
        }

        yield return StartCoroutine(loadNextScene());
    }

    IEnumerator loadNextScene() 
    {
        yield return new WaitForSeconds(10f);

        float textAlpha = text.color.a;

        Color textFadeColor = text.color;

        float elapsedTime = 0f;
        float fadeDuration = 2f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the normalized alpha value based on the elapsed time
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);

            // Fade the disclaimer text
            textFadeColor = text.color;
            textFadeColor.a = Mathf.Lerp(textAlpha, 0f, normalizedTime);
            text.color = textFadeColor;

            yield return null;
        }

        SceneManager.LoadScene(0);
    }


}
