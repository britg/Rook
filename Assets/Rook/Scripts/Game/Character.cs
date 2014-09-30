using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : IReceiveAction {

    public GameObject go { get; set; }

    public abstract CharacterAlignment alignment { get; }

	public CharacterAttribute hitPoints { get; set; }
	public virtual CharacterAttribute actionPoints { get; set; }
	public CharacterAttribute armorRating { get; set; }
	public CharacterAttribute attackRating { get; set; }
	public CharacterAttribute detectRange { get; set; }

    CharacterAction _action;
	public virtual CharacterAction action {
        get {
            return _action;
        }
        set {
            _action = value;
            _action.owner = this;
        }
    }

    public virtual void ResetActionPoints () {
        actionPoints.SetToMax();
    }

	public bool InDetectionRange (float distance) {
		return distance <= (float)detectRange.maxValue;
	}

	public bool Detect (GameObject other) {
        float otherDistance = Vector3.Distance(other.transform.position, go.transform.position);
		return InDetectionRange(otherDistance);
	}

	public bool HasEnoughActionPoints (CharacterAction action) {
		return actionPoints.currentValue >= action.actionPointCost;
	}

	public List<IReceiveAction> TargetsInRange (GridService gridService) {
		var targetsInRange = new List<IReceiveAction>();
		List<Vector3> pointsToCheck = gridService.WorldPointsForAction(action);
		foreach (Vector3 pointToCheck in pointsToCheck) {
			var t = GetTargetsAtPoint(pointToCheck);
			if (t.Count > 0) {
				targetsInRange.AddRange(t);
			}
		}
		return targetsInRange;
	}

	List<IReceiveAction> GetTargetsAtPoint (Vector3 point) {
		float sphereRadius = 0.5f;
		
		// get direction to move destination
		Vector3 start = go.transform.position; 
		start.y = sphereRadius;
		Vector3 direction = point - start;
		
		// get distance to move destination
		float dist = Vector3.Distance(start, point);
		RaycastHit[] hits = Physics.SphereCastAll(start, sphereRadius, direction, dist);
		
		var targets = new List<IReceiveAction>();
		foreach (RaycastHit hit in hits) {
			var hitObj = hit.collider.gameObject;
			var gc = hitObj.GetComponent<GameController>();
			if (gc != null && gc.actionReceiver != null) {
				Debug.Log ("Action receiver is " + gc.actionReceiver);
				targets.Add(gc.actionReceiver);
			}
		}
		return targets;
	}
}
