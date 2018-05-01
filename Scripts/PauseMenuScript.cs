using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : LevelManagerScript {

    public static bool isPaused;
    public GameObject pauseMenu;
    AudioSource music;
    public void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        music = FindObjectOfType<MusicManagerScript>().GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.pauseSound);
            isPaused = !isPaused;
            Time.timeScale = (isPaused) ? 0 : 1;
            pauseMenu.SetActive(isPaused);
            music.Pause();
            if (isPaused) music.Pause(); if (!isPaused) music.Play();
        }

    }
    public void ResumeGame()
    {
        SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.resumeSound);
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        music.Play();
    }
}
