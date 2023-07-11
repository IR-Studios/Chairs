using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DemoMenu : MonoBehaviour
{
    public GameObject DisclaimerUI, AnyButtonUI, MenuUI;

    [Header("Disclaimer Section")]
    public TextMeshProUGUI DisclaimerText;
    public Image Background;

    [Header("Any Button Section")]
    public TextMeshProUGUI AnyButtonText;
    public Image Logo;
    public Image IRLogo1;
    public bool isActive = false;

    [Header("MenuUI Section")] 
    
        public Image logo2;
        public Image IRlogo;

        public TextMeshProUGUI Play, Quit;

    FirstLoad FL;
    

    void Awake() 
    {
       

    }

    void Start() 
    {
        FL = GameObject.Find("FirstLoad").GetComponent<FirstLoad>();




        if (FL.isFirstLoad) 
        {
            DisclaimerUI.SetActive(true);
            AnyButtonUI.SetActive(false);
            MenuUI.SetActive(false);
            StartCoroutine(FadeDisclaimer());
        } else 
        {
            DisclaimerUI.SetActive(false);
            TransitionToNextScreen();
        }

       
    }
    
    void Update() 
    {
        if (isActive) 
        {
            if (Input.anyKeyDown) 
            {
                StartCoroutine(FadeOutMenuTwo());
            }
        }
    }

    public void LoadScene() 
    {
        StartCoroutine(LoadingScene());
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    IEnumerator LoadingScene() 
    {
        float textAlpha = 0f;
        float logoAlpha = 0f;

        Color textFadeColor1 = Play.color;
        Color textFadeColor2 = Quit.color;

        Color logoColor = logo2.color;
        Color IRColor = IRlogo.color;

        float fadeDuration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
        
            // Calculate the normalized alpha value based on the elapsed time
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
        
            // Fade the Play Button
            textFadeColor1.a = Mathf.Lerp(textAlpha, 0f, normalizedTime);
            Play.color = textFadeColor1;

            //Fade the Quit Button
            textFadeColor2.a = Mathf.Lerp(textAlpha, 0f, normalizedTime);
            Quit.color = textFadeColor2;
        
            // Fade the Logo
            logoColor.a = Mathf.Lerp(logoAlpha, 0f, normalizedTime);
            logo2.color = logoColor;

            //Fade the IR Logo
            IRColor.a = Mathf.Lerp(logoAlpha, 0f, normalizedTime);
            IRlogo.color = logoColor;
        
            yield return null;
        }

        SceneManager.LoadScene(1);
    }

    IEnumerator FadeOutMenuTwo() 
    {
        
    // Set the initial alpha values
    float textAlpha = 1f;
    float logoAlpha = 1f;
    
    // Set the initial color values
    Color textFadeColor = AnyButtonText.color;
    Color logoColor = Logo.color;
    Color IRLogoColor = IRLogo1.color;
    
    // Fade duration and elapsed time
    float fadeDuration = 2f; // Duration for the fade effect (in seconds)
    float elapsedTime = 0f;
    
    while (elapsedTime < fadeDuration)
    {
        elapsedTime += Time.deltaTime;
        
        // Calculate the normalized alpha value based on the elapsed time
        float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
        
        // Fade the AnyButtonText
        textFadeColor.a = Mathf.Lerp(textAlpha, 0f, normalizedTime);
        AnyButtonText.color = textFadeColor;
        
        // Fade the Logo
        logoColor.a = Mathf.Lerp(logoAlpha, 0f, normalizedTime);
        Logo.color = logoColor;

        // Fade the IR Logo
        IRLogoColor.a = Mathf.Lerp(logoAlpha, 0f, normalizedTime);
        IRLogo1.color = IRLogoColor;
        
        yield return null;
    }

        AnyButtonUI.SetActive(false);
        isActive = false;
        LaunchMenuUI();
    }

    void LaunchMenuUI() 
    {
        MenuUI.SetActive(true);
        StartCoroutine(FadeInMenuUI());
    }

    IEnumerator FadeInMenuUI() 
    {
        float textAlpha = 0f;
        float logoAlpha = 0f;

        Color textFadeColor1 = Play.color;
        Color textFadeColor2 = Quit.color;

        Color logoColor = logo2.color;
        Color IRColor = IRlogo.color;

        float fadeDuration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
        
            // Calculate the normalized alpha value based on the elapsed time
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
        
            // Fade the Play Button
            textFadeColor1.a = Mathf.Lerp(textAlpha, 1f, normalizedTime);
            Play.color = textFadeColor1;

            //Fade the Quit Button
            textFadeColor2.a = Mathf.Lerp(textAlpha, 1f, normalizedTime);
            Quit.color = textFadeColor2;
        
            // Fade the Logo
            logoColor.a = Mathf.Lerp(logoAlpha, 1f, normalizedTime);
            logo2.color = logoColor;

            //Fade the IR Logo
            IRColor.a = Mathf.Lerp(logoAlpha, 1f, normalizedTime);
            IRlogo.color = logoColor;
        
            yield return null;
        }

    }

     IEnumerator FadeDisclaimer()
    {
        yield return new WaitForSeconds(5f);
        // Get the initial alpha value of the disclaimer text
        float textAlpha = DisclaimerText.color.a;

        // Fade the text
        float elapsedTime = 0f;
        float fadeDuration = 2f; // Duration for the text fade effect (in seconds)

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the normalized alpha value based on the elapsed time
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);

            // Fade the disclaimer text
            Color textFadeColor = DisclaimerText.color;
            textFadeColor.a = Mathf.Lerp(textAlpha, 0f, normalizedTime);
            DisclaimerText.color = textFadeColor;

            yield return null;
        }

        // Wait for a one-second delay
        yield return new WaitForSeconds(1f);

        // Get the initial alpha value of the background
        float backgroundAlpha = Background.color.a;

        // Fade the background
        elapsedTime = 0f;
        fadeDuration = 2f; // Duration for the background fade effect (in seconds)

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the normalized alpha value based on the elapsed time
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);

            // Fade the background
            Color backgroundFadeColor = Background.color;
            backgroundFadeColor.a = Mathf.Lerp(backgroundAlpha, 0f, normalizedTime);
            Background.color = backgroundFadeColor;

            yield return null;
        }

        FL.isFirstLoad = false;

        // Deactivate the disclaimer UI and proceed to the next screen
        DisclaimerUI.SetActive(false);
        // Call the method to transition to the next screen or perform any desired action
        TransitionToNextScreen();
    }
    void TransitionToNextScreen()
    {
        AnyButtonUI.SetActive(true);
        isActive = true;
        StartCoroutine(FadeUpAny());
    }

  IEnumerator FadeUpAny()
{
    yield return new WaitForSeconds(1f);
    
    // Set the initial alpha values
    float textAlpha = 0f;
    float logoAlpha = 0f;
    
    // Set the initial color values
    Color textFadeColor = AnyButtonText.color;
    Color logoColor = Logo.color;
    Color IRLogoColor = IRLogo1.color;
    
    // Fade duration and elapsed time
    float fadeDuration = 2f; // Duration for the fade effect (in seconds)
    float elapsedTime = 0f;
    
    while (elapsedTime < fadeDuration)
    {
        elapsedTime += Time.deltaTime;
        
        // Calculate the normalized alpha value based on the elapsed time
        float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
        
        // Fade the AnyButtonText
        textFadeColor.a = Mathf.Lerp(textAlpha, 1f, normalizedTime);
        AnyButtonText.color = textFadeColor;
        
        // Fade the Logo
        logoColor.a = Mathf.Lerp(logoAlpha, 1f, normalizedTime);
        Logo.color = logoColor;

        // Fade the IR Logo
        IRLogoColor.a = Mathf.Lerp(logoAlpha, 1f, normalizedTime);
        IRLogo1.color = IRLogoColor;
        
        yield return null;
    }
}

}
