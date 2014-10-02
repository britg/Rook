using UnityEngine;
using System.Collections;

public class EndTurnAction : GameAction {

	public override string ActionType {
		get {
			return "EndTurnAction";
		}
	}
	
	public override string Name {
		get {
			return "End Turn";
		}
	}

}
