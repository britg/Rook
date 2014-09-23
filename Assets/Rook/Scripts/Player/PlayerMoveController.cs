using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;

public class PlayerMoveController : GameController {

    public float lineWidth;
    public Color lineColor;
    public float moveTime;
    public int maxWaypoints {
		get {
			return player.actionPoints.currentValue;
		}
	}

    VectorLine line;
    List<Vector3> waypoints;
    Vector3 lastWaypoint {
        get {
            if (waypoints.Count > 0) {
                return waypoints[waypoints.Count - 1];
            } else {
                return transform.position;
            }
        }
    }
    Vector3 moveDestination;
    int currentMoveIndex = 0;

    void Start () {
        waypoints = new List<Vector3>();
    }

    void Update () {

    }

    void CreateLine () {
        Vector3 start = Vector3.zero;
        Vector3 end = Vector3.zero;
        line = VectorLine.SetLine3D(lineColor, new Vector3[2] { start, end });
        line.SetWidth(lineWidth, 0);
        line.Draw3DAuto();
    }

    void Redraw () {
        if (line == null) {
            CreateLine();
        }

		if (waypoints.Count < 1) {
			return;
		}

        line.Resize(waypoints.Count + 1);
        line.points3[0] = transform.position;

        for (int i = 0; i < waypoints.Count; i++) {
            Vector3 p = waypoints[i];
            line.points3[i + 1] = p;
        }
    }

    void Reset () {
        currentMoveIndex = 0;
        VectorLine.Destroy(ref line);
        waypoints = new List<Vector3>();
    }

    // Called from Player Mouse Move Controller FSM
    public void UpdateMoveDestination (Vector3 pos) {
        moveDestination = gridService.NearestCellCenter(pos);
		UpdateWaypoints();
	}

	public void UpdateWaypoints () {
        moveDestination.y = transform.position.y;

        if (DestinationOccupied() || !DestinationValid()) {
            return;
        }

        if (moveDestination.Equals(transform.position)) {
            Reset();
            return;
        }

        // First waypoint
        if (waypoints.Count == 0 && maxWaypoints > 0) {
            waypoints.Add(moveDestination);
            Redraw();
            return;
        } 

		// check if moveDestination is the same as the last waypoint
        if (moveDestination.Equals(lastWaypoint)) {
            Redraw();
            return;
        }

        if (waypoints.Count >= maxWaypoints) {
            Redraw();
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

        waypoints.Add(moveDestination);
        Redraw();
    }

    bool DestinationOccupied () {
        float sphereRadius = 0.5f;

        // get direction to move destination
        Vector3 start = lastWaypoint; 
        start.y = sphereRadius;
        Vector3 direction = moveDestination - start;

        // get distance to move destination
        float dist = Vector3.Distance(start, moveDestination);
        RaycastHit[] hits = Physics.SphereCastAll(start, sphereRadius, direction, dist);
		return PlayerMove.BlockedBy(hits);
    }

	bool DestinationValid () {
		return PlayerMove.ValidMove(moveDestination, waypoints);
	}

    // Called from Player Mouse Move Controller FSM
    public void MoveFinished () {
        NextMove();
    }

    void NextMove () {
        if (currentMoveIndex >= waypoints.Count) {
            FinishMove();
            return;
        }
        Vector3 waypoint = waypoints[currentMoveIndex];
        iTween.MoveTo(gameObject, iTween.Hash("position", waypoint,
            "time", moveTime,
            "oncomplete", "NextMove"));
        currentMoveIndex++;
		player.actionPoints.Decrement();
    }

    void FinishMove () {
        Reset();
		NotificationCenter.PostNotification(this, Notifications.ActionFinished);
    }


}
