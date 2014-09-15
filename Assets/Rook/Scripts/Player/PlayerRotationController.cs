using UnityEngine;
using System.Collections;

public class PlayerRotationController : GameController {

    public float rotateAngle = 60f;
    public float rotateTime = 0.2f;

    Vector3 aimPoint;
    public Transform aimProxy;

    public bool isRotating {
        get {
            return player.isRotating;
        }
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
    }

    public void SetAimPoint (Vector3 _aimPoint) {
        aimPoint = _aimPoint;
        RotateToAimPoint();
    }

    void RotateToAimPoint () {
        aimProxy.LookAt(aimPoint);
        Vector3 angles = aimProxy.eulerAngles;
        float angle = angles.y;
        float remain = angle % rotateAngle;
        float nearest = 0f;
        if (remain > rotateAngle / 2f) {
            nearest = Mathf.Ceil(angle / rotateAngle) * rotateAngle;
        } else {
            nearest = Mathf.Floor(angle / rotateAngle) * rotateAngle;
        }

        angles.y = nearest;
        transform.eulerAngles = angles;
    }

    void RotateToTouch () {

    }

}
