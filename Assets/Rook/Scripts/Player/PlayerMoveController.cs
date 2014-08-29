using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;

public class PlayerMoveController : GameController {

    public GFHexGrid grid;
    public float lineWidth;
    public Color lineColor;

    VectorLine line;
    List<Vector3> waypoints;
    Vector3 moveDestination;

	void Start () {
        CreateLine();
        waypoints = new List<Vector3>();
	}
	
	void Update () {
	    
	}

    void CreateLine () {
        Vector3 start = Vector3.zero;
        Vector3 end = Vector3.zero;
        line = VectorLine.SetLine3D(lineColor, new Vector3[]{ start, end });
        line.SetWidth(lineWidth, 0);
    }

    void Redraw () {
        line.points3 = new Vector3[waypoints.Count + 1];
        line.points3[0] = transform.position;

        for (int i = 0; i < waypoints.Count; i++) {
            Vector3 p = waypoints[i];
            Debug.Log("Redrawing " + i + " " + p);
            line.points3[i+1] = p;
            if (i > 0) {
                //line.SetWidth(lineWidth, i-1);
            }
        }


        line.Draw3D();
    }

    void Reset () {
        line.points3 = new Vector3[] { Vector3.zero, Vector3.zero };
        waypoints = new List<Vector3>();
    }

    // Called from Player Mouse Move Controller FSM
    public void UpdateMoveDestination (Vector3 pos) {
        moveDestination = grid.NearestFaceW(pos);

        // check if moveDestination is the same as the last waypoint
        if (waypoints.Count > 0 && moveDestination.Equals(waypoints[waypoints.Count - 1])) {
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
        Reset();
        iTween.MoveTo(gameObject, iTween.Hash("position", moveDestination, 
            "time", 0.5f));
        EndTurn();
    }

    void EndTurn () {
        turnController.EndTurn();
    }


}
