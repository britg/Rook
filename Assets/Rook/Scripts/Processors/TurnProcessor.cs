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

	void Start () {
		Register (GameAction.ActionId.StartPlayerTurn, StartTurn);
	}

	public override void Process (GameAction action) {

		switch (action.id) {

		case GameAction.ActionId.StartPlayerTurn:
			StartTurn();
			break;

		case GameAction.ActionId.EndPlayerTurn:
			EndTurn();
			break;

		}
	}

	void StartTurn (GameAction action) {
		StartTurn();
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

	void EndTurn (GameAction action) {
		EndTurn();
	}

}
