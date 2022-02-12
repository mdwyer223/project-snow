using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomEnvironment : MonoBehaviour {

    public GameObject playerPrefab;
    public static bool isGamePaused;

    void Start() {
        Instantiate(playerPrefab);
    }
}
