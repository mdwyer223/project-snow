using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour {

    public static UnityEvent playerPause;
    public static UnityEvent playerInteract;
    public static UnityEvent startDialogue;

    public static void LoadEvents() {
        // Set up player events
        playerPause = playerPause != null ? playerPause : new UnityEvent();
        playerInteract = playerInteract != null ? playerInteract : new UnityEvent();
    }
}

