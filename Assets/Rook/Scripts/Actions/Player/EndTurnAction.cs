using UnityEngine;
using System.Collections;

public class EndTurnAction : GameAction {

	public override string ActionType {
		get {
			return "TurnAction";
		}
	}
	
	public override string Name {
		get {
			return "End";
		}
	}

	public override ActionId id {
		get {
			return ActionId.EndPlayerTurn;
		}
	}

}
