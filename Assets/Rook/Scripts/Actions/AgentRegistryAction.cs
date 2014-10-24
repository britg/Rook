using UnityEngine;
using System.Collections;

public class AgentRegistryAction : GameAction {

	public override string ActionType {
		get {
			return "AgentRegistry";
		}
	}

	public override string Name {
		get {
			return "Start Turn";
		}
	}
}
