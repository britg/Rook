using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : IReceiveAction {

    public GameObject go { get; set; }

    public abstract CharacterAlignment alignment { get; }
	public PlayerControlMode controlMode;

	public virtual CharacterAttribute hitPoints { get; set; }
	public virtual CharacterAttribute actionPoints { get; set; }
	public virtual CharacterAttribute armorRating { get; set; }
	public virtual CharacterAttribute attackRating { get; set; }
	public virtual CharacterAttribute detectRange { get; set; }
	public virtual Color color { get; set; }

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

	public Character () {

	}

	public Character (GameObject _go) {
		go = _go;
	}

    public virtual void ResetActionPoints () {
        actionPoints.SetToMax();
    }

	public bool InDetectionRange (float distance) {
		return distance <= (float)detectRange.maxValue;
	}

	public bool Detect (GameObject other) {
		// Needs to be refactored to use
		// raycasting against walls/etc. in the way
        float otherDistance = Vector3.Distance(other.transform.position, go.transform.position);
		return InDetectionRange(otherDistance);
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

}
