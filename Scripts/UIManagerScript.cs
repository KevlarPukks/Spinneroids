using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
    public static UIManagerScript instance;
    public Text waveNumber;
    public Text scoreText;
    public GameObject healthSlider;
    public GameObject shieldSlider;
    public int score;
    void Awake()
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
        score = 0;
        AddScore(0);
        WaveNumber(0);
        
    }


    public void AddScore(int scoreTooAdd)
    {
        score += scoreTooAdd;
        scoreText.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
    public void WaveNumber(int wave)
    {
        waveNumber.text = "Wave:\n" + wave.ToString();
    }
    public void ShieldSlider(float shieldhealth)
    {
        shieldSlider.transform.localScale = new Vector2(shieldhealth / 15, shieldSlider.transform.localScale.y);
    }
   public void HealthSlider(float health)
    {
        healthSlider.transform.localScale = new Vector2(health / 10, shieldSlider.transform.localScale.y);
    }
}
