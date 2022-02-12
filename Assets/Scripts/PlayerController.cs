using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 5f;

    public List<Sprite> walkLeftFrames;
    public List<Sprite> walkRightFrames;
    public List<Sprite> walkUpFrames;
    public List<Sprite> walkDownFrames;

    int frameCounter;
    int frameTickCounter;
    int frameTickSwitch;
    int numFrames;

    Rigidbody2D body;
    SpriteRenderer sprite;

    Vector2 movement;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        frameCounter = 0;
        frameTickCounter = 0;
        frameTickSwitch = 214;
        numFrames = 4;
        movement = new Vector2();
    }

    // Update is called once per frame
    void Update() {
        MovementInput();
        UpdateSprite();
    }

    // Update is called once per tick
    void FixedUpdate() {
        body.velocity = (movement * movementSpeed);
    }

    void MovementInput() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(x, y).normalized;
    }

    void UpdateSprite() {
        frameTickCounter++;
        if (frameTickCounter % frameTickSwitch == 0) {
            frameTickCounter = 0;
        } else {
            return;
        }

        Sprite frame = walkDownFrames[0];
        if (movement.x == 0 && movement.y == 0) {
            frameCounter = 0;
        }
        if (movement.y > 0) {
            frame = walkUpFrames[frameCounter];
        } else if (movement.y < 0) {
            frame = walkDownFrames[frameCounter];
        }
        if (movement.x > 0) {
            frame = walkRightFrames[frameCounter];
        } else if (movement.x < 0) {
            frame = walkLeftFrames[frameCounter];
        }



        sprite.sprite = frame;
        frameCounter++;
        if (frameCounter >= numFrames) {
            frameCounter = 0;
        }
    }
}
