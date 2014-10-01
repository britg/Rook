using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveProcessor : ActionProcessor {
	
	public override string ActionType {
		get {
			return "MoveAction";
		}
	}
	
	public float moveTime;
	
	int currentMoveIndex = 0;
	public MoveAction moveAction;

	List<Vector3> waypoints {
		get {
			return moveAction.waypoints;
		}
	}
	
	public override void Process (GameAction action) {
		currentMoveIndex = 0;
		moveAction = (MoveAction)action;
		NextMove();
	}
	
	void NextMove () {
		if (currentMoveIndex >= waypoints.Count) {
			DoneProcessing();
			return;
		}
		Vector3 waypoint = waypoints[currentMoveIndex];
		iTween.MoveTo(moveAction.go, iTween.Hash("position", waypoint,
		                                         "time", moveTime,
		                                         "oncomplete", "NextMove",
		                                         "oncompletetarget", gameObject));
		currentMoveIndex++;
		moveAction.character.actionPoints.Decrement(moveAction.actionPointCost);
	}

	public override void DoneProcessing () {
		base.DoneProcessing();
	}
	
}
