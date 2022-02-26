using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public static CameraManager Instance;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private int cameraHeight;

    private Transform target;

    void Start() {
        Instance = this;
    }

    void Update() {
        if (target == null) {
            return;
        }

        Vector3 targetPosition = target.position + new Vector3(0, 0, -cameraHeight);
        mainCamera.transform.position = targetPosition;
    }

    public void SetTarget(Transform target) {
        this.target = target;
    }
}
