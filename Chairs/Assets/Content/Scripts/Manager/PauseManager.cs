using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;

    [Header("Gameobjects")]
    public GameObject PausedMenu;

    private AudioSource[] allAudioSources;
    private bool wasAudioPaused;

    private FirstPersonAIO player;
    private Player p;

    private void Start()
    {
        // Get all AudioSources in the scene
        allAudioSources = FindObjectsOfType<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonAIO>();
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !p.inJumpscare)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !p.isDead)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void QuitGame() 
    {
        SceneManager.LoadScene(0);
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Freeze the game

        // Show the pause menu
        PausedMenu.SetActive(true);
    }

    public void ResumeGame()
{
    isPaused = false;
    Time.timeScale = 1f; // Resume normal time scale

    player.controllerPauseState = false;
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;

    // Hide the pause menu
    PausedMenu.SetActive(false);
}
}
