using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScript : MonoBehaviour {
    public PlayerHealth player;
    public GameObject losePanel;
    public GameObject UI;
    public GameObject pausePanel;
    
    public Text score;
    public Text highScore;
    EnemyHealth[] enemies;
    RockBehaviour[] rocksAndPickups;
    public static bool isGameover;

	// Use this for initialization
	void Start () {
        Debug.Log(player.health);
        isGameover = false;
        UI.SetActive(true);
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(player.health);
        if (player.health <= 0)
        {
            isGameover = true;
            
            Destroy(player.gameObject);
            GameManager.instance.SmallExplosion(player.gameObject.transform.position);
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.explosionSound);
            FindObjectOfType<MusicManagerScript>().audioSource.Pause();
           StartCoroutine("EndScore");
           enemies = FindObjectsOfType<EnemyHealth>();
            rocksAndPickups = FindObjectsOfType<RockBehaviour>();
            foreach (EnemyHealth enemy in enemies)
            {
                float destroytime = Random.Range(0.5f, 2);
                Destroy(enemy.gameObject, destroytime);
                if (enemy.gameObject.GetComponent<Renderer>().isVisible)
                {
                  
                    StartCoroutine(EndExplosion(enemy.gameObject.transform.position, SoundManager.instance.explosionSound, destroytime));
                }
               
            }
            foreach (RockBehaviour rock in rocksAndPickups)
            {
                float destroytime = Random.Range(0.5f, 2);
                Destroy(rock.gameObject, destroytime);
 if (rock.gameObject.GetComponent<Renderer>().isVisible)
                {
                    
                    StartCoroutine(EndExplosion(rock.gameObject.transform.position, SoundManager.instance.explosionSound, destroytime));
                }
            }
        }
	}
    IEnumerator EndScore()
    {
        SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.loseSound);
        score.text = "You Scored:\n" + UIManagerScript.instance.score.ToString();
        if(PlayerPrefsManager.GetHighScore() < UIManagerScript.instance.score)
        {
            PlayerPrefsManager.SetHighScore(UIManagerScript.instance.score);
        }
        highScore.text = "HighScore:\n" + PlayerPrefsManager.GetHighScore().ToString();
        UI.SetActive(false);
        yield return new WaitForSeconds(1);
        losePanel.SetActive(true);

    }
    IEnumerator EndExplosion(Vector2 explosionPosition, AudioClip explosionAudioClip, float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        GameManager.instance.SmallExplosion(explosionPosition);
        SoundManager.instance.sfx.PlayOneShot(explosionAudioClip);
    }

}
