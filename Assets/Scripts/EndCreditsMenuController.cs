using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCreditsMenuController : MonoBehaviour {

    public void TitleScreen() {
        SceneController.LoadScene(SceneController.getTitleSceneName());
    }

    public void QuitGame() {
        Application.Quit();
    }
}
