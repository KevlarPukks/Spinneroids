using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    public Slider volSlider;
    public LevelManagerScript levelManagerScript;
    public Slider diffSlider;
  
    public GameObject pauseMenu;
    public GameObject options;
    public Slider sfx;
    public AudioSource Soundfx;
	// Use this for initialization
	void Start () {
    
   
    
        volSlider.value = PlayerPrefsManager.GetMasterVolume();

      
	}
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = volSlider.value;
       

	}
    public void Click()
    {
        SoundManager.instance.sfx.PlayOneShot(levelManagerScript.click);
    }
    public void Return()
    {
        options.SetActive(false);
        pauseMenu.SetActive(true);
        PlayerPrefsManager.SetMasterVolume(volSlider.value);
       
    }
    public void OptionsMenu()
    {
        options.SetActive(true);
        pauseMenu.SetActive(false);

    }
    public void SetDefaults()
    {
        volSlider.value = 0.8f;
        diffSlider.value = 2;
    }
}
