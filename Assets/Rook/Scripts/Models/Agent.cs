using UnityEngine;
using System.Collections;

public abstract class Agent :  IReceiveAction {

	public GameObject go { get; set; }
	public virtual AgentAttribute hitPoints { get; set; }
	public virtual AgentAttribute actionPoints { get; set; }
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

	// Actions
	public virtual GameAction turnAction { get; set; }

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

	public virtual void TakeDamage (int amount) {
		hitPoints.Decrement(amount);
		
		Debug.Log ("Took damage " + amount);
		Debug.Log ("Current hp: " + hitPoints.currentValue);
		
		if (hitPoints.currentValue <= 0) {
			Die();
		}
	}

	
	protected virtual void Die () {
		Debug.Log("I'm dead");
		state = State.Dead;
	}

}
