using UnityEngine;
using System.Collections;

public class StartTurnAction : GameAction {
	
	public override string ActionType {
		get {
			return "StartTurnAction";
		}
	}
	
	public override string Name {
		get {
			return "Start Turn";
		}
	}
	
}
