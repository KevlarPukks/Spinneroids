using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource sfx;
    [Header("Sound Effects")]
    public AudioClip playerLaserSound;
    public AudioClip enemyLaserSound;
    public AudioClip explosionSound;
    public AudioClip shieldDownSound;
    public AudioClip shieldPickupSound;
    public AudioClip rapidFirePickupSound;
    public AudioClip novaPickupSound;
    public AudioClip pauseSound;
    public AudioClip resumeSound;
    public AudioClip healthLowSound;
    public AudioClip loseSound;
    public AudioClip newWaveSound;
    public AudioClip gameStartSound;
    public AudioClip enemyHitSound;
    public AudioClip shieldHitSound;
    public AudioClip playerHitSound;
    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            //  DontDestroyOnLoad(gameObject);

        }
    }
    private void Start()
    {
        sfx.clip = gameStartSound;
        sfx.Play();
    }
}
