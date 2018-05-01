using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour {
 
    public AudioClip[] LevelMusicChangeArray;
    public AudioSource audioSource;
     PlayerHealth player;
    int health;
    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "Level01")
        {

        }
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            player =FindObjectOfType<PlayerHealth>();
            if (player == null)
                health = 0;
            else
            health = player.health;

            if (health >= 5)
            {
                audioSource.pitch = 1;
            }
            if (health < 5)
            {
                audioSource.pitch = 1.1f;
            }
            if (health <= 2)
            {
                audioSource.pitch = 1.2f;
            }
        }
    }
    private void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
      
    }
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = LevelMusicChangeArray[scene.buildIndex];
        Debug.Log("Scene loaded is: " + scene.name);
        Debug.Log(scene.buildIndex);
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void ChangeVolume(float volume)
    {
       AudioListener.volume = volume;
    }
}
