using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAction : GameAction {

	public override string ActionType {
		get {
			return "MoveAction";
		}
	}

    public List<Vector3> waypoints;
    public Vector3 lastWaypoint {
        get {
            if (waypoints.Count > 0) {
                return waypoints[waypoints.Count - 1];
            } else {
				return agentPosition;
            }
        }
    }
	public bool valid {
		get {
			return waypoints.Count > 0;
		}
	}


	MoveView moveView;

	public GameObject go {
		get {
			return agent.go;
		}
	}

	public Vector3 agentPosition {
		get {
			return agent.position;
		}
	}

	public MoveAction (Character _c) {
		agent = (Agent)_c;
		moveView = null;
		waypoints = new List<Vector3>();
	}

	public MoveAction (Character _c, MoveView view) {
		agent = (Agent)_c;
		waypoints = new List<Vector3>();
		ConnectMoveView(view);
	}

	public void ConnectMoveView (MoveView view) {
		if (view == null) {
			return;
		}
		moveView = view;
		moveView.moveAction = this;
		Redraw();
	}

	public void AddWaypoint (Vector3 point, bool inCombat) {

		Vector3 moveDestination = point;
		moveDestination.y = agentPosition.y;
		
		if (!PathfindingService.DestinationValid(agent.go, waypoints, moveDestination)) {
			Debug.Log ("Destination is not valid -- need to do some real pathfinding here.");
			return;
		}
		
		if (moveDestination.Equals(agentPosition)) {
			Reset();
			return;
		}
		
		// First waypoint
		if (waypoints.Count == 0 && agent.actionPoints.currentValue > 0) {
			waypoints.Add(moveDestination);
			Redraw();
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

		if (inCombat && waypoints.Count >= agent.actionPoints.currentValue) {
			return;
		}

		waypoints.Add(moveDestination);
		Redraw();
	}

	void Redraw () {
		if (moveView != null) {
			moveView.Redraw();
		}
	}

	public void Reset () {
		waypoints = new List<Vector3>();
		if (moveView != null) {
			moveView.Reset();
		}
	}

	public override void Done () {
		if (moveView != null) {
			moveView.Reset();
		}
	}

}
