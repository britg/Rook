using UnityEngine;
using System.Collections;

public class StartEnemyTurnAction : GameAction {
	
	public override string ActionType {
		get {
			return "EnemyTurnAction";
		}
	}
	
	public override string Name {
		get {
			return "Start";
		}
	}

	public Enemy enemy;

	public StartEnemyTurnAction (Enemy _enemy) {
		enemy = _enemy;
	}
	
}
