using UnityEngine;
using System.Collections;

public class ContinueEnemyTurnAction : GameAction {
	
	public override string ActionType {
		get {
			return "EnemyTurnAction";
		}
	}
	
	public override string Name {
		get {
			return "Continue";
		}
	}
	
	public Enemy enemy;
	
	public ContinueEnemyTurnAction (Enemy _enemy) {
		enemy = _enemy;
	}
	
}
