using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;

public class PlayerMoveController : GameController {

	MoveAction currentMoveAction;
	MoveView moveView;

	void Awake () {
		RequireMoveView();
	}

	void RequireMoveView () {
		moveView = gameObject.AddComponent<MoveView>();
	}

	void MoveInputStart () {
		currentMoveAction = new MoveAction(player, moveView);
	}

	void MoveInputUpdate (Vector3 pos) {
        Vector3 waypoint = gridService.NearestCellCenter(pos);
		currentMoveAction.AddWaypoint(waypoint);
	}

	void MoveInputFinished () {
		actionQueueController.Add(currentMoveAction);
	}

}
