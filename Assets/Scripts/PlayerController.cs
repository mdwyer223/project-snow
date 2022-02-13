using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class PlayerController : MonoBehaviour {

    enum Direction {
        Left, Right, Up, Down
    }

    public float movementSpeed = 5f;

    Rigidbody2D body;

    SpriteResolver resolver;
    SpriteRenderer sprite;

    string spriteDirection;
    string spriteCategory;
    string spriteLabel;

    string previousSpriteCategory;
    string previousSpriteLabel;

    float idleTime;
    int frameRate = 8;

    Vector2 movement;

    void Start() {
        body = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();
        resolver = GetComponent<SpriteResolver>();

        movement = new Vector2();

        spriteDirection = Direction.Down.ToString();
        spriteCategory = "WalkDown";
        spriteLabel = "1";
    }

    // Update is called once per frame
    void Update() {
        MovementInput();
        UpdateSprite();
    }

    void MovementInput() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(x, y).normalized;
        body.velocity = (movement * movementSpeed);
    }

    void UpdateSprite() {
        previousSpriteCategory = spriteCategory;
        previousSpriteLabel = spriteLabel;

        if (movement.y > 0) {
            spriteDirection = Direction.Up.ToString();
        } else if (movement.y < 0) {
            spriteDirection = Direction.Down.ToString();
        }

        if (movement.x > 0) {
            spriteDirection = Direction.Right.ToString();
        } else if (movement.x < 0) {
            spriteDirection = Direction.Left.ToString();
        }

        spriteCategory = "Walk" + spriteDirection;
        if (movement.x == 0 && movement.y == 0) {
            spriteLabel = "1";
            idleTime = Time.time;
        } else {
            float playTime = Time.time - idleTime;
            int totalFrames = (int)(playTime * frameRate);
            int frame = totalFrames % 4;

            spriteLabel = frame.ToString();
        }

        if (spriteCategory != previousSpriteCategory || spriteLabel != previousSpriteLabel) {
            resolver.SetCategoryAndLabel(spriteCategory, spriteLabel);
            resolver.ResolveSpriteToSpriteRenderer();
        }
    }
}
