using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterTownEnvironment : MonoBehaviour {

    public GameObject pauseMenuPrefab;
    public GameObject playerPrefab;
    public GameObject targetCameraPrefab;

    void Start() {
        Instantiate(pauseMenuPrefab);

        Instantiate(playerPrefab);
        Instantiate(targetCameraPrefab);

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");

        cameraObject.GetComponent<TargetCameraController>().SetTarget(playerObject.gameObject);
    }
}
