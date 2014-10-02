using UnityEngine;
using System.Collections;

public class EndTurnProcessor : ActionProcessor {

	public override string ActionType {
		get {
			return "EndTurnAction";
		}
	}

	EndTurnAction action;

	public override void Process (GameAction action) {
		turnController.EndTurn();
		DoneProcessing();
	}

}
