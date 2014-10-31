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
			actionQueueController.Add(action);
		}
		DoneProcessing();
	}

}
