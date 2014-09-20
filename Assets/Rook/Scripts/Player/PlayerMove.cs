using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove {

    Player player;
	List<Vector3> waypoints;
    public int maxWaypoints {
        get {
            return player.actionPoints.currentValue;
        }
    }

	public PlayerMove (Player _player) {
        player = _player;
	}

    public void AddWaypoint (Vector3 waypoint) {
        if (ValidateWaypoint(waypoint)) {
            waypoints.Add(waypoint);
        }
    }

    bool ValidateWaypoint (Vector3 waypoint) {
        return true;
    }

	public bool Validate () {
		return false;
	}
}
