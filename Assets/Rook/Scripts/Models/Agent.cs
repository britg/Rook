using UnityEngine;
using System.Collections;

public abstract class Agent :  IReceiveAction {

	public bool dead;
	public virtual CharacterAttribute hitPoints { get; set; }

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
