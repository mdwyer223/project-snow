using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public void StartGame() {
        Debug.Log("Start button clicked!");
        SceneController.LoadScene(SceneController.getBedroomSceneName());
    }

    public void LoadGame() {
        Debug.Log("Load button clicked!");
    }

    public void Options() {
        Debug.Log("Options button clicked!");
    }

    public void QuitGame() {
        Debug.Log("Quit button clicked!");
        Application.Quit();
    }

}
