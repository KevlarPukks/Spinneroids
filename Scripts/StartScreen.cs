using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

public	void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
