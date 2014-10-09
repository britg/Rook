using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class PathfindingService {

	static List<string> nonBlockingTags = new List<string>{ "Player", "Grid", "Floor" };

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

	public MoveAction GetMoveAction () {
		GetPath();
		var moveAction = new MoveAction(mover);
		foreach (Vector3 waypoint in waypoints) {
			moveAction.AddWaypoint(waypoint);
		}
		return moveAction;
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
		Vector3 towardsTarget = lastWaypoint + (target - lastWaypoint).normalized * GridService.gridUnit;
		Vector3 nearestCell = gridService.NearestCellCenter(towardsTarget);
		Vector3 targetCell = gridService.NearestCellCenter(target);

		if (nearestCell.Equals(targetCell)) {
			return;
		}

		waypoints.Add (nearestCell);
	}

	public static bool DestinationValid (GameObject go, List<Vector3> waypoints, Vector3 moveDestination) {
		return !DestinationOccupied(go, waypoints, moveDestination);
	}
	
	public static bool DestinationOccupied (GameObject go, List<Vector3> waypoints,  Vector3 moveDestination) {
		float sphereRadius = GridService.gridUnit/2f;
		
		// get direction to move destination
		Vector3 start;
		if (waypoints.Count > 0) {
			start = waypoints[waypoints.Count-1];
		} else {
			start = go.transform.position;
		}

		start.y = sphereRadius;
		Vector3 direction = moveDestination - start;
		
		// get distance to move destination
		float dist = Vector3.Distance(start, moveDestination);
		RaycastHit[] hits = Physics.SphereCastAll(start, sphereRadius, direction, dist);
		return BlockedBy(go, hits);
	}
	
	public static bool BlockedBy (GameObject go, RaycastHit[] hits) {
		foreach (RaycastHit hit in hits) {
			if (hit.collider.gameObject != go && !nonBlockingTags.Contains(hit.collider.gameObject.tag)) {
				Debug.Log ("Blocked by " + hit.collider.gameObject.tag + " " + hit.collider.gameObject);
				return true;
			}
		}
		
		return false;
	}

}
