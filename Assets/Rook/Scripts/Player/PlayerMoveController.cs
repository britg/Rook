using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;

public class PlayerMoveController : GameController {

    public GFHexGrid grid;
    public float lineWidth;
    public Color lineColor;
    public float moveTime;

    VectorLine line;
    List<Vector3> waypoints;
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
        line = VectorLine.SetLine3D(lineColor, new Vector3[2]{ start, end });
        line.SetWidth(lineWidth, 0);
        line.Draw3DAuto();
    }

    void Redraw () {
        if (line == null) {
            CreateLine();
        }

        line.Resize(waypoints.Count+1);
        line.points3[0] = transform.position;

        for (int i = 0; i < waypoints.Count; i++) {
            Vector3 p = waypoints[i];
            line.points3[i+1] = p;
        }
    }

    void Reset () {
        currentMoveIndex = 0;
        VectorLine.Destroy(ref line);
        waypoints = new List<Vector3>();
    }

    // Called from Player Mouse Move Controller FSM
    public void UpdateMoveDestination (Vector3 pos) {
        moveDestination = grid.NearestFaceW(pos);
        moveDestination.y = transform.position.y;

        // First waypoint
        if (waypoints.Count == 0) {
            if (moveDestination.Equals(transform.position)) {
                return;
            }

            waypoints.Add(moveDestination);
            Redraw();
            return;
        }

        // In Combat, only one waypoint allowed
        if (InCombat && waypoints.Count == 1) {
            Redraw();
            return;
        }

        // check if moveDestination is the same as the last waypoint
        Vector3 lastWaypoint = waypoints[waypoints.Count - 1];
        if (moveDestination.Equals(lastWaypoint)) {
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
    }

    void FinishMove () {
        Reset();
        EndTurn();
    }


}
