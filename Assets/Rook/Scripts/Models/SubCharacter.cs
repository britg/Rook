using UnityEngine;
using System.Collections;

public abstract class SubCharacter : Character {

	public Player player;

	public override AgentAttribute actionPoints {
		get {
			return player.actionPoints;
		}
		set {
		}
	}

	public SubCharacter (GameObject _go) : base(_go) {

	}

    public override void TakeDamage (int amount) {
		player.TakeDamage(amount);
    }

}
