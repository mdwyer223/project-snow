using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : BaseInteractableObject {
    
    [SerializeField]
    private TextAsset dialgoueFile;
    
    private Dialogue dialogue;
    private int lineIndex;

    void Start() {
        lineIndex = 0;
        Debug.Log(dialgoueFile.text);
        this.dialogue = JsonUtility.FromJson<Dialogue>(dialgoueFile.text);

        Debug.Log(this.dialogue.lines);
    }

    public override void Interact() {
        string firstLine = this.dialogue.lines[lineIndex];
        DialogueManager.Instance.InitiateDialogue(
            this, firstLine
        );
    }

    public string NextLine() {
        lineIndex++;

        if (lineIndex < dialogue.lines.Count) {
            return dialogue.lines[lineIndex];
        }

        return null;
    }

    public void EndDialogue() {
        lineIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "PlayerInteract") {
            this.Interact();
        }
    }
}

