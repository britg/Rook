using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : Agent {

    public abstract CharacterAlignment alignment { get; }
	public PlayerControlMode controlMode;

	public virtual bool isPlayer { get; set; }

	public virtual AgentAttribute armorRating { get; set; }
	public virtual AgentAttribute attackRating { get; set; }
	public virtual AgentAttribute detectRange { get; set; }

	public virtual bool inCombat { get; set; }
    public virtual Character combatTarget { get; set; }


    GameAction _action;
	public virtual GameAction action {
        get {
            return _action;
        }
        set {
            _action = value;
            _action.agent = (Agent)this;
        }
    }

	public Character (GameObject _go) : base(_go) {
		isPlayer = false;
	}

	public bool Detect (Character other) {
		var service = new DetectionService(this, other);
		return service.Detect();
	}

	public void EnterMode (PlayerControlMode mode) {
		Debug.Log("Entering mode " + mode + " with game object " + go);
		controlMode = mode;
	}

    public virtual void SnapToGrid (GridService gridService) {
        go.transform.position = gridService.NearestCellCenter(go.transform.position);
    }

	public virtual void RotateToTarget (Vector3 target) {
		go.transform.LookAt (target);
		Vector3 angles = go.transform.eulerAngles;
		float angle = angles.y;
		float remain = angle % GridService.rotationAngle;
		float nearest = 0f;
		if (remain > GridService.rotationAngle / 2f) {
			nearest = Mathf.Ceil(angle / GridService.rotationAngle) * GridService.rotationAngle;
		} else {
			nearest = Mathf.Floor(angle / GridService.rotationAngle) * GridService.rotationAngle;
		}
		
		angles.y = nearest;
		go.transform.eulerAngles = angles;
	}

}
