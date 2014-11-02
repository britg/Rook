using UnityEngine;
using System.Collections;

public class AgentRegistryProcessor : ActionProcessor {

	AgentRegistry _agentRegistry;
	public override AgentRegistry agentRegistry { 
		get {
			if (_agentRegistry == null) {
				_agentRegistry = new AgentRegistry();
			}
			return _agentRegistry;
		}
	}

	public override string ActionType {
		get {
			return "AgentRegistry";
		}
	}

	public override void Process (GameAction action) {
		switch (action.Name) {
		case "StartTurns":
			StartTurns();
			break;
		case "Refresh":
			Refresh();
			break;
		}
	}

	void Refresh () {
		// Any agent on the grid should be awoken.
		DoneProcessing();
	}

	void StartTurns () {
		agentRegistry.SeedTurns();
		ContinueTurns();
	}

	void ContinueTurns () {
		Agent nextAgent = agentRegistry.NextAgentTakingTurn();
		Debug.Log ("Next agent taking turn is " + nextAgent);
		GameAction action = nextAgent.turnAction;
		if (action != null) {
			actionQueue.Add(action);
		}
		DoneProcessing();
	}

}
