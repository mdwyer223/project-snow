using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutsceneController : MonoBehaviour {

    public GameObject sunnyPanel;
    public GameObject woodsyPanel;
    public GameObject ruinsPanel;

    float timePassed;

    void Start() {
        sunnyPanel.SetActive(true);
        woodsyPanel.SetActive(false);
        ruinsPanel.SetActive(false);

        timePassed = 0;
    }

    void Update() {
        timePassed += Time.time;

        if (timePassed > 200000) {
            SceneController.LoadScene(SceneController.getBedroomSceneName());
        } else if (timePassed > 100000) {
            ruinsPanel.SetActive(true);
            woodsyPanel.SetActive(false);
            sunnyPanel.SetActive(false);
        }
        else if (timePassed > 25000) {
            woodsyPanel.SetActive(true);
            sunnyPanel.SetActive(false);
            ruinsPanel.SetActive(false);
        }   
    }
}
