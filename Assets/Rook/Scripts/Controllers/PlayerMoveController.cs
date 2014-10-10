using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;

public class PlayerMoveController : GameController {

	MoveAction currentMoveAction;

	void Awake () {
	}

	void MoveInputStart () {
		currentMoveAction = new MoveAction(player, moveView);
	}

	void MoveInputUpdate (Vector3 pos) {
        Vector3 waypoint = gridService.NearestCellCenter(pos);
		currentMoveAction.AddWaypoint(waypoint);
	}

	void MoveInputFinished () {
		if (currentMoveAction.valid) {
			moveView.DisplayConfirmation();
//			actionQueueController.Add(currentMoveAction);

		}
	}

	void MoveInputAuto (Vector3 destination) {
		if (GUIInteraction()) {
			Debug.Log ("GUI Interaction");
			return;
		}
		Debug.Log ("Move auto to " + destination);
		var pathfinder = new PathfindingService(player, destination, gridService);
		var moveAction = pathfinder.GetMoveAction(moveView);
		moveView.DisplayConfirmation();
//		actionQueueController.Add (moveAction);
	}

}
