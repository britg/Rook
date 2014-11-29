using UnityEngine;
using System.Collections;

public class StartTurnAction : GameAction {
	
	public override string ActionType {
		get {
			return "TurnAction";
		}
	}
	
	public override string Name {
		get {
			return "Start";
		}
	}

	public override ActionId id {
		get {
			return GameAction.ActionId.StartPlayerTurn;
		}
	}
	
}
