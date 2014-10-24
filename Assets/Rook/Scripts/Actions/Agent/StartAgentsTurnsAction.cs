using UnityEngine;
using System.Collections;

public class StartAgentsTurnsAction : GameAction {

	public override string ActionType {
		get {
			return "AgentRegistry";
		}
	}

	public override string Name {
		get {
			return "StartTurns";
		}
	}
}
