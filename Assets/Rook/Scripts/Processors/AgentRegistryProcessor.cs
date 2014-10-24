using UnityEngine;
using System.Collections;

public class AgentRegistryProcessor : ActionProcessor {

	public override AgentRegistry agentRegistry { get; set; }

	public override string ActionType {
		get {
			return "AgentRegistry";
		}
	}

	void Awake () {
		agentRegistry = new AgentRegistry();
	}

	public override void Process (GameAction action) {
		Debug.Log ("Agent registry processing " + action);
	}

}
