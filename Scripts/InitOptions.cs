using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitOptions : MonoBehaviour {
    private MusicManagerScript musicManager;
    public GameObject OptionsPanel;
    public GameObject mainMenu;
    public Text highscore1;
    public GameObject fader;
    private void OnEnable()
    {
        musicManager = FindObjectOfType<MusicManagerScript>();

    }
    // Use this for initialization
    void Start () {
        fader.SetActive(true);
        Debug.Log(PlayerPrefsManager.GetMasterVolume().ToString());
      highscore1.text = "HighScore:\n" + PlayerPrefsManager.GetHighScore().ToString();
   
        mainMenu.SetActive(true);
        OptionsPanel.SetActive(false);
       if (PlayerPrefsManager.VolumeExists())
            musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        else musicManager.ChangeVolume(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
