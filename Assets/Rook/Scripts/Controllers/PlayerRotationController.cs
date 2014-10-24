using UnityEngine;
using System.Collections;

public class PlayerRotationController : GameBehaviour {

	PlayerRotationAction rotationAction;
	PlayerRotationView _rotationView;
    PlayerRotationView rotationView {
		get {
			if (_rotationView == null) {
				_rotationView = GetComponent<PlayerRotationView>();
			}
			return _rotationView;
		}
	}

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
		rotationAction = new PlayerRotationAction(player);
		rotationView.Init(rotationAction);
	}

	public void UpdateRotateInput (Vector3 _aimPoint) {
		rotationAction.UpdateAimPoint(_aimPoint);
		rotationView.Display();
	}

	public void CommitRotateInput () {
		Debug.Log ("Commit called");
		rotationView.Clear();
		if (isRotating) {
			actionQueueController.Add(rotationAction);
		}
	}

}
