using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCameraController : MonoBehaviour {

    public int height;
    GameObject target;

    // Update is called once per frame
    void Update() {
        if (target != null) {
            Vector3 targetPosition = new Vector3(target.gameObject.transform.position.x, target.gameObject.transform.position.y, height);
            this.gameObject.transform.position = targetPosition;
        }
    }

    public void SetTarget(GameObject gameObject) {
        this.target = gameObject;
    }
}
