using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController {

    public static string getBedroomSceneName() {
        return "Scenes/Bedroom";
    }

    public static string getTitleSceneName() {
        return "Scenes/Title";
    }

    public static string getStarterTownSceneName() {
        return "Scenes/StarterTown";
    }
    
    public static string getEndCreditsSceneName() {
        return "Scenes/EndCredits";
    }

    public static string getIntroSceneName() {
        return "Scenes/OpeningScene";
    }

    public static void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
