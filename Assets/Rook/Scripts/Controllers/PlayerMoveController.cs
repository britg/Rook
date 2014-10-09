using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;

public class PlayerMoveController : GameController {

	MoveAction currentMoveAction;

	void Awake () {
	}

	void MoveInputStart () {
		currentMoveAction = new MoveAction(player, moveView, combatService.InCombat);
	}

	void MoveInputUpdate (Vector3 pos) {
        Vector3 waypoint = gridService.NearestCellCenter(pos);
		currentMoveAction.AddWaypoint(waypoint);
	}

	void MoveInputFinished () {
		if (currentMoveAction.valid) {
//			moveView.DisplayConfirmation();
			actionQueueController.Add(currentMoveAction);

		}
	}

}
