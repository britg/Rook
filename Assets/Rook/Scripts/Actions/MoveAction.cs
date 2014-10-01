using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAction : GameAction {

	public override string ActionType {
		get {
			return "MoveAction";
		}
	}

	static List<string> nonBlockingTags = new List<string>{ "Player", "Grid", "Floor" };

	public override Character character { get; set; }
    public List<Vector3> waypoints;
    public Vector3 lastWaypoint {
        get {
            if (waypoints.Count > 0) {
                return waypoints[waypoints.Count - 1];
            } else {
				return characterPosition;
            }
        }
    }

	MoveView moveView;

	public GameObject go {
		get {
			return character.go;
		}
	}

	public Vector3 characterPosition {
		get {
			return character.go.transform.position;
		}
	}

	public int maxMoves {
		get {
			return character.actionPoints.currentValue;
		}
	}

	public MoveAction (Character _c, MoveView view) {
		character = _c;
		moveView = view;
		moveView.moveAction = this;
		waypoints = new List<Vector3>();
	}

	public void AddWaypoint (Vector3 point) {

		Vector3 moveDestination = point;
		moveDestination.y = characterPosition.y;
		
		if (!DestinationValid(moveDestination)) {
			return;
		}
		
		if (moveDestination.Equals(characterPosition)) {
			Reset();
			return;
		}
		
		// First waypoint
		if (waypoints.Count == 0 && maxMoves > 0) {
			waypoints.Add(moveDestination);
			moveView.Redraw();
			return;
		} 
		
		// check if moveDestination is the same as the last waypoint
		if (moveDestination.Equals(lastWaypoint)) {
			return;
		}
		
		Vector3 p;
		for (int i = 0; i < waypoints.Count; i++) {
			p = waypoints[i];
			if (moveDestination == p) {
				List<Vector3> newWaypoints = waypoints.GetRange(0, i);
				waypoints = newWaypoints;
				return;
			}
		}

		if (waypoints.Count >= maxMoves) {
			return;
		}

		waypoints.Add(moveDestination);
		moveView.Redraw();
	}

	void Reset () {
		waypoints = new List<Vector3>();
		moveView.Reset();
	}

	public override void Done () {
		moveView.Reset();
	}

	bool DestinationValid (Vector3 moveDestination) {
		return !DestinationOccupied(moveDestination);
	}
	
	bool DestinationOccupied (Vector3 moveDestination) {
		float sphereRadius = GridService.gridUnit/2f;
		
		// get direction to move destination
		Vector3 start = lastWaypoint; 
		start.y = sphereRadius;
		Vector3 direction = moveDestination - start;
		
		// get distance to move destination
		float dist = Vector3.Distance(start, moveDestination);
		RaycastHit[] hits = Physics.SphereCastAll(start, sphereRadius, direction, dist);
		return BlockedBy(hits);
	}

	public static bool BlockedBy (RaycastHit[] hits) {
		foreach (RaycastHit hit in hits) {
			if (!nonBlockingTags.Contains(hit.collider.gameObject.tag)) {
				Debug.Log ("Blocked by " + hit.collider.gameObject.tag);
				return true;
			}
		}
		
		return false;
	}
	
}
