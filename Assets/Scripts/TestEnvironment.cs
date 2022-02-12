using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnvironment : MonoBehaviour {

    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start() {
        Instantiate(playerPrefab);   
    }
}
