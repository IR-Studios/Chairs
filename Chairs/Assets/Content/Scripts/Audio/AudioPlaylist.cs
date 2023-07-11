using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlaylist : MonoBehaviour
{
    public List<AudioClip> audioClips;
    private AudioSource audioSource;
    private int currentIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextClip();
    }

    void PlayNextClip()
    {
        if (currentIndex >= audioClips.Count)
        {
            // Reset currentIndex to loop through the playlist again
            return;
        }

        audioSource.clip = audioClips[currentIndex];
        audioSource.Play();

        StartCoroutine(WaitForClipToEnd());
    }

    IEnumerator WaitForClipToEnd()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        
        currentIndex++;
        PlayNextClip();
    }
}

