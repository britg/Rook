using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Player player;

    public bool isMoving {
        get {
            return player.isMoving;
        }
    }

    void Start () {
        player.EnterMode(PlayerControlMode.Move);
    }

    public void RotateButtonPressed () {
        ToggleRotateMode();
    }

    public void ToggleRotateMode () {
        if (player.isRotating) {
            player.EnterMode(PlayerControlMode.Move);
        } else {
            player.EnterMode(PlayerControlMode.Rotate);
        }
    }

    public void WarriorActionButtonPressed () {
        player.EnterMode(PlayerControlMode.WarriorAction);
    }

}
