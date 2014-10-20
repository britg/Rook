using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : IReceiveAction {

    public GameObject go { get; set; }

    public abstract CharacterAlignment alignment { get; }
	public PlayerControlMode controlMode;

	public virtual bool isPlayer { get; set; }

	public virtual CharacterAttribute hitPoints { get; set; }
	public virtual CharacterAttribute actionPoints { get; set; }
	public virtual CharacterAttribute armorRating { get; set; }
	public virtual CharacterAttribute attackRating { get; set; }
	public virtual CharacterAttribute detectRange { get; set; }
	public virtual Color color { get; set; }

	public virtual bool inCombat { get; set; }
    public virtual Character combatTarget { get; set; }

	public bool dead;

    GameAction _action;
	public virtual GameAction action {
        get {
            return _action;
        }
        set {
            _action = value;
            _action.character = this;
        }
    }

    public virtual float rotation {
        get {
            return go.transform.eulerAngles.y;
        }
    }

    public virtual Vector3 position {
        get {
            return go.transform.position;
        }
        set {
            go.transform.position = value;
        }
    }

	public Character () {

	}

	public Character (GameObject _go) {
		go = _go;
		isPlayer = false;
	}

    public virtual void ResetActionPoints () {
        actionPoints.SetToMax();
    }

	public bool Detect (Character other) {
		var service = new DetectionService(this, other);
		return service.Detect();
	}

	public virtual void TakeDamage (int amount) {
		hitPoints.Decrement(amount);

		Debug.Log ("Took damage " + amount);
		Debug.Log ("Current hp: " + hitPoints.currentValue);

		if (hitPoints.currentValue <= 0) {
			Die();
		}
	}

	void Die () {
		Debug.Log("I'm dead");
		dead = true;
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
