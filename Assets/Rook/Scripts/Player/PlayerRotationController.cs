using UnityEngine;
using System.Collections;

public class PlayerRotationController : GameController {

    public float rotateAngle = 60f;
    public float rotateTime = 0.2f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        WatchRotateMode();
    }

    public void OnRotateRight () {
        RotateRight();
    }

    public void OnRotateLeft () {
        RotateLeft();
    }

    void RotateRight () {
        if (!PlayerTurn) {
            return;
        }
        iTween.RotateBy(gameObject, iTween.Hash("y", rotateAngle / 360f,
            "time", rotateTime));
        EndTurn();
    }

    void RotateLeft () {
        if (!PlayerTurn) {
            return;
        }
        iTween.RotateBy(gameObject, iTween.Hash("y", -rotateAngle / 360f,
            "time", rotateTime));
        EndTurn();
    }

    public void StartRotateMode () {
        playerController.SetPlayerMode(PlayerMode.Rotate);
    }

    void WatchRotateMode () {
        if (player.mode == PlayerMode.Rotate) {
            RotateToInput();
        }
    }

    void RotateToInput () {
        RotateToMouse();
        RotateToTouch();
    }

    void RotateToMouse () {
        
    }

    void RotateToTouch () {

    }

}
