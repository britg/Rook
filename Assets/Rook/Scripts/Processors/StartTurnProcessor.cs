using UnityEngine;
using System.Collections;

public class StartTurnProcessor : ActionProcessor {
	
	public override string ActionType {
		get {
			return "StartTurnAction";
		}
	}
	
	StartTurnAction action;
	
	public override void Process (GameAction action) {
		turnController.StartTurn();
		DoneProcessing();
	}
	
}
