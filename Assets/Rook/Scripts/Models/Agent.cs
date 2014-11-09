using UnityEngine;
using System.Collections;

public abstract class Agent :  IReceiveAction {

	public AgentController controller;

	public GameObject go { get; set; }

	public virtual AgentAttribute hitPoints { get; set; }
	public virtual AgentAttribute actionPoints { get; set; }

	public virtual AgentAttribute detectRange { get; set; }
	public virtual AgentAttribute attackRange { get; set; }

	public virtual AgentAttribute armorRating { get; set; }
	public virtual AgentAttribute attackRating { get; set; }

	public virtual Color color { get; set; }

	enum State {
		Idle,
		Active,
		InCombat,
		Dead
	}

	State state = State.Idle;
	public bool dead {
		get {
			return state == State.Dead;
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

	public virtual float rotation {
		get {
			return go.transform.eulerAngles.y;
		}
	}

	public Agent (GameObject _go) {
		go = _go;
	}

    public virtual void ResetActionPoints () {
        actionPoints.SetToMax();
    }

	public virtual bool CanDetect (Agent other) {
		var service = new DetectionService(this, other);
		return service.Detect();
	}

	public virtual bool CanReach (Agent other) {
		return false;
	}

	public virtual void TakeTurn () {
		controller.TurnFinished();
	}

	public virtual void TakeDamage (int amount) {
		hitPoints.Decrement(amount);
		
		Debug.Log ("Took damage " + amount);
		Debug.Log ("Current hp: " + hitPoints.currentValue);
		
		if (hitPoints.currentValue <= 0) {
			Die();
		}
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

	public virtual void SnapToGrid (GridService gridService) {
		go.transform.position = gridService.NearestCellCenter(go.transform.position);
	}

	protected virtual void Die () {
		Debug.Log("I'm dead");
		state = State.Dead;
	}

}
