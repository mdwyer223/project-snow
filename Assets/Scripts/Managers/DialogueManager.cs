using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
     public static DialogueManager Instance;
    
    [SerializeField]
    private GameObject dialogueCanvas;

    [SerializeField]
    private TextMeshProUGUI dialogueText;

    private bool inDialogue;
    private Npc npc;

    void Start() {
        Instance = this;
        inDialogue = false;
    }

    public void InitiateDialogue(Npc npc, string firstLine) {
        dialogueText.text = firstLine;

        this.npc = npc;
        dialogueCanvas.SetActive(true);
        PlayerController.Instance.PausePlayer();
        inDialogue = true;
    }

    public void EndDialogue() {
        this.npc.EndDialogue();
        this.npc = null;
        dialogueCanvas.SetActive(false);
        PlayerController.Instance.ResumePlayer();
        inDialogue = false;
    }

    void Update() {
        if (inDialogue) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                string line = npc.NextLine();
                dialogueText.text = line;

                if (line == null) {
                    EndDialogue();
                }
            }
        }
    }
}
