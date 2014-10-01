using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class PlayerMove {

	static List<string> nonBlockingTags = new List<string>{ "Player", "Grid", "Floor" };

	public static bool BlockedBy (GameObject go) {
		return false;
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

	public static bool ValidMove (Vector3 destination, List<Vector3> waypoints) {
		return true;
	}

}
