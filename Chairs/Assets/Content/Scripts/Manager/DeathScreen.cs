using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI title;

    public GameObject Menu;

    [Header("Respawn")]
    public AudioSource music;
    public Transform respawnPoint;
    public Transform chairRespawnPoint;
    public GameObject chair;
    public GameObject jumpScareChair;
    public GameObject player;
    public GameObject rope;
    public FirstPersonAIO player2;
    public Player p;
    
    public void LoadLastCheckpoint() 
    {
        music.Stop();
        jumpScareChair.SetActive(false);

        player.transform.position = respawnPoint.position;
        player2.sprintSpeed = 3;
        rope.SetActive(true);
        chair.transform.position = chairRespawnPoint.position;
        chair.transform.rotation = chairRespawnPoint.rotation;
        chair.SetActive(false);

        Menu.SetActive(false);
        player2.controllerPauseState = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        p.isDead = false;
    }

    void QuitGame() 
    {
        SceneManager.LoadScene(0);
    }
}
