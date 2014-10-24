using UnityEngine;
using System.Collections;

public abstract class Agent :  IReceiveAction {

	public bool dead;
	public GameObject go { get; set; }
	public virtual CharacterAttribute hitPoints { get; set; }
	public virtual CharacterAttribute actionPoints { get; set; }

	public virtual Vector3 position {
        get {
            return go.transform.position;
        }
        set {
            go.transform.position = value;
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
		dead = true;
	}

}
