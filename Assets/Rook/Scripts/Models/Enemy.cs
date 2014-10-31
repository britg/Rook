using UnityEngine;
using System.Collections;

public class Enemy : Character {

	public Enemy (GameObject _go) : base(_go) {

	}

	public override CharacterAlignment alignment {
		get {
			return CharacterAlignment.Enemy;
		}
	}

	public override GameAction turnAction {
		get {
			return new StartEnemyTurnAction(this);
		}
		set {
			base.turnAction = value;
		}
	}

}
