using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public static bool isGamePaused;
    public GameObject pauseUI;

    void Start() {
        pauseUI.SetActive(false);
        isGamePaused = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        pauseUI.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        pauseUI.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
    }

    public void TitleMenu() {
        ResumeGame();
        SceneController.LoadScene(SceneController.getTitleSceneName());
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
