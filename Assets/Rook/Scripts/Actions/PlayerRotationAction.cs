using UnityEngine;
using System.Collections;

public class PlayerRotationAction : GameAction {

    public override string ActionType {
        get {
            return "PlayerRotationAction";
        }
    }

	public override int actionPointCost {
		get {
			return 1;
		}
	}

	GameObject playerObj {
        get {
            return agent.go;
        }
    }

	public Vector3 aimPoint;
    public Transform aimProxy { 
		get {
			return playerObj.transform.FindChild("AimProxy").transform;
		}
	}

	public PlayerRotationAction (Character c) {
        agent = (Agent)c;
	}

	public void UpdateAimPoint (Vector3 _aimPoint) {
		aimPoint = _aimPoint;
	}

}
