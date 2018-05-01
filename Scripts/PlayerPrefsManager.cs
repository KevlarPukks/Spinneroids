using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string SFX_KEY = "sfx";
    const string HIGHSCORE_KEY = "HighScore";
    
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.Log("Master volume out of range");
        }
    }
        public static float GetMasterVolume()
        {
      return  PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        }
   public static void SetHighScore(int highscore)
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, highscore);
    }
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY);
    }
    public static void SetSFX(float volume)
    {
        PlayerPrefs.SetFloat(SFX_KEY, volume);
    }
    public static float GetSFX()
    {
        return PlayerPrefs.GetFloat(SFX_KEY);

    }
    public static bool VolumeExists()
    {
        return PlayerPrefs.HasKey(MASTER_VOLUME_KEY);
    } 
 
   
}
