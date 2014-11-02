using UnityEngine;
using System.Collections;

public class TurnProcessor : ActionProcessor {

	public override TurnService turnService { get; set; }

	public override string ActionType {
		get {
			return "TurnAction";
		}
	}

	void Awake () {
		turnService = new TurnService();
	}

	public override void Process (GameAction action) {

		switch (action.Name) {

		case "Start":
			StartTurn();
			break;

		case "End":
			EndTurn();
			break;

		}
	}

	void StartTurn () {
		turnService.StartPlayerTurn();
		DoneProcessing();
	}

	void EndTurn () {
		turnService.EndPlayerTurn();
		actionQueue.Add(new StartAgentsTurnsAction());
		DoneProcessing();
	}

}
