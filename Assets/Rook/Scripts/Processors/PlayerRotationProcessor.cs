using UnityEngine;
using System.Collections;

public class PlayerRotationProcessor : ActionProcessor {

	public override string ActionType {
		get {
			return "PlayerRotationAction";
		}
	}

	public float rotateTime = 0.2f;
	PlayerRotationAction rotationAction;

	Transform aimProxy {
		get {
			return rotationAction.aimProxy;
		}
	}

	Vector3 aimPoint {
		get {
			return rotationAction.aimPoint;
		}
	}

	public override void Process (GameAction _rotationAction) {
		rotationAction = (PlayerRotationAction)_rotationAction;
		RotateToAimPoint();
	}

	void RotateToAimPoint () {
		aimProxy.LookAt(aimPoint);
		Vector3 angles = aimProxy.eulerAngles;
		float angle = angles.y;
		float remain = angle % GridService.rotationAngle;
		float nearest = 0f;
		if (remain > GridService.rotationAngle / 2f) {
			nearest = Mathf.Ceil(angle / GridService.rotationAngle) * GridService.rotationAngle;
		} else {
			nearest = Mathf.Floor(angle / GridService.rotationAngle) * GridService.rotationAngle;
		}

		angles.x = 0f;
		angles.z = 0f;
		angles.y = nearest;
		iTween.RotateTo(playerObj, iTween.Hash("rotation", angles, 
		                                       "time", rotateTime,
		                                       "oncompletetarget", gameObject,
		                                       "oncomplete", "RotationDoneProcessing"));
	}

	public void RotationDoneProcessing () {
		playerController.EnterMode(PlayerControlMode.Move);
		rotationAction.SpendActionPoints();
		DoneProcessing();
	}


}
