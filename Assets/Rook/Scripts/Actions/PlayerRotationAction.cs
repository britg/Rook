using UnityEngine;
using System.Collections;

public class PlayerRotationAction : GameAction {


	public override int actionPointCost {
		get {
			return 1;
		}
	}

	GameObject playerObj;
	public Vector3 aimPoint;
    public Transform aimProxy { 
		get {
			return playerObj.transform.FindChild("AimProxy").transform;
		}
	}

	public PlayerRotationAction (GameObject _playerObj) {
		playerObj = _playerObj;
	}

	public void UpdateAimPoint (Vector3 _aimPoint) {
		aimPoint = _aimPoint;
	}

}
