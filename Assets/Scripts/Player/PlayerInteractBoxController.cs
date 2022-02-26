using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractBoxController : MonoBehaviour {
    [SerializeField]
    private int resetTime;

    private int resetTimer;

    void Awake() {
        resetTimer = 0;
    }

    void Update() {
        resetTimer++;
        if (resetTimer > resetTime) {
            this.gameObject.SetActive(false);
        }
    }

    void OnEnable() {
        resetTimer = 0;
    }

    void OnDisable() {
        resetTimer = 0;
    }
}
