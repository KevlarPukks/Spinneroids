using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManagerScript : MonoBehaviour {
 public   Animator animator;
    public AudioClip click;

    public AudioSource audioSource;
    public void StartGame() {
        StartCoroutine("startRoutine");
        Time.timeScale = 1;
    }
    void FadeOut()
    {
        animator.SetTrigger("fadeOut");
    }
    IEnumerator startRoutine()
    {
        audioSource.PlayOneShot(click);
        FadeOut();
        yield return new WaitForSeconds(1);
  SceneManager.LoadScene("Level01");
    }
    IEnumerator optionsRoutine()
    {
        audioSource.PlayOneShot(click);
        FadeOut();
        yield return new WaitForSeconds(1);
        OptionsController Options = FindObjectOfType<OptionsController>();
        Options.OptionsMenu();
    }
   public void Options()
    {
        StartCoroutine("optionsRoutine");
    }
    public void QuitGame()
    {
        StartCoroutine("quitRoutine");
    }
    public void LoadMainMenu()
    {
      
        PauseMenuScript.isPaused = false;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    IEnumerator quitRoutine()
    {
        audioSource.PlayOneShot(click);
        FadeOut();
        yield return new WaitForSeconds(1);

        Application.Quit();
    }
    public void Quit()
    {
       
       
        Application.Quit();
    }
  public void Restart()
    {
        
        PauseMenuScript.isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
      
    }
    public void Click()
    {
        audioSource.PlayOneShot(click);   
    }
  
}
