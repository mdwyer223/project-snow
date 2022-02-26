using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instance;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private int frameRate;

    [SerializeField]
    private GameObject interactBox;

    enum Direction {
        Left, Right, Up, Down
    }

    Rigidbody2D body;

    SpriteResolver resolver;
    SpriteRenderer sprite;

    string spriteDirection;
    string spriteCategory;
    string spriteLabel;

    string previousSpriteCategory;
    string previousSpriteLabel;

    float idleTime;

    bool playerPaused = false;
    bool cameraTargeted = false;

    Vector2 movement;

    void Start() {
        Instance = this;

        body = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();
        resolver = GetComponent<SpriteResolver>();

        movement = new Vector2();

        spriteDirection = Direction.Down.ToString();
        spriteCategory = "WalkDown";
        spriteLabel = "1";
    }

    void Update() {
        if (playerPaused) {
            body.velocity = Vector2.zero;
            return;
        }

        if (!cameraTargeted) {
            CameraManager.Instance.SetTarget(this.gameObject.transform);
            cameraTargeted = true;
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Interact();
        }

        MovementInput();
        UpdateSprite();
    }

    void Interact() {
        interactBox.SetActive(true);
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
            UpdateInteractBox();
            resolver.SetCategoryAndLabel(spriteCategory, spriteLabel);
            resolver.ResolveSpriteToSpriteRenderer();
        }
    }

    void UpdateInteractBox() {
        Vector3 playerPosition = this.transform.position;
        if (spriteDirection == Direction.Up.ToString()) {
            interactBox.gameObject.transform.position =  playerPosition + new Vector3(0, .6f);
        } else if (spriteDirection == Direction.Down.ToString()) {
            interactBox.gameObject.transform.position = playerPosition + new Vector3(0, -.6f);
        } else if (spriteDirection == Direction.Left.ToString()) {
            interactBox.gameObject.transform.position = playerPosition + new Vector3(-.6f, 0);
        } else if (spriteDirection == Direction.Right.ToString()) {
            interactBox.gameObject.transform.position =  playerPosition + new Vector3(.6f, 0);
        } else {
            interactBox.gameObject.transform.position = playerPosition + new Vector3(0, 0);
        }
    }

    public void PausePlayer() {
        playerPaused = true;
    }

    public void ResumePlayer() {
        playerPaused = false;
    }
}
