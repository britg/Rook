using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class PathfindingService {

	Character mover;
	Vector3 target;
	GridService gridService;
	List<Vector3> waypoints;
	Vector3 lastWaypoint {
		get {
			if (waypoints.Count < 1) {
				return mover.go.transform.position;
			}
			return waypoints[waypoints.Count-1];
		}
	}

	public PathfindingService (Character _mover, Vector3 _target, GridService _gridService) {
		mover = _mover;
		target = _target;
		gridService = _gridService;
	}

	public List<Vector3> GetPath () {
		waypoints = new List<Vector3>();
		int max = mover.actionPoints.currentValue;

		for (int i = 0; i < max; i++) {
			NextWaypoint();
		}
		return waypoints;
	}

	void NextWaypoint () {
		Debug.Log ("last waypoint is " + lastWaypoint);
		Vector3 towardsTarget = lastWaypoint + (target - lastWaypoint).normalized * GridService.gridUnit;
		Vector3 nearestCell = gridService.NearestCellCenter(towardsTarget);
		Vector3 targetCell = gridService.NearestCellCenter(target);

		if (nearestCell.Equals(targetCell)) {
			return;
		}

		waypoints.Add (nearestCell);
	}
}
