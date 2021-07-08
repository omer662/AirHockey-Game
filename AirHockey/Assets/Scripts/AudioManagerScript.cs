using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioClip PuckCollision;
    public AudioClip Goal;
    public AudioClip WonGame;
    public AudioClip LostGame;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }

    public void PlayWonGame()
    {
        audioSource.PlayOneShot(WonGame);
    }

    public void PlayLostGame()
    {
        audioSource.PlayOneShot(LostGame);
    }
}
