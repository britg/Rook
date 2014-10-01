using UnityEngine;
using System.Collections;

public class PlayerRotationController : GameController {

    Vector3 aimPoint;

	PlayerRotationAction rotationAction;
	PlayerRotationView rotationView;

    public bool isRotating {
        get {
            return player.isRotating;
        }
    }

    public void RotateButtonPressed () {
		Debug.Log ("Rotate called");
        ToggleRotateMode();
    }

    public void ToggleRotateMode () {
        if (isRotating) {
			playerController.EnterMode(PlayerControlMode.Move);
        } else {
			if (player.actionPoints.currentValue > 0) {
				playerController.EnterMode(PlayerControlMode.Rotate);
				StartRotate();
			}
        }
    }

	void StartRotate () {
		rotationAction = new PlayerRotationAction(playerObj);
	}

	public void UpdateRotateInput (Vector3 _aimPoint) {
		rotationAction.UpdateAimPoint(_aimPoint);
	}

	public void CommitRotateInput () {
		Debug.Log ("Commit called");
		if (isRotating) {
			actionQueueController.Add(rotationAction);
		}
	}

}
