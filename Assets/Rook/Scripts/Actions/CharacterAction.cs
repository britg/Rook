using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

[System.Serializable]
public class CharacterAction : GameAction  {

    public List<IReceiveAction> targets;
	public PlayerControlMode controlMode;

	public string name;
	public int _actionPointCost;
	public override int actionPointCost {
		get {
			return _actionPointCost;
		}
	}

	public ValueRange damage;
	public int requiredTargetCount = 1;

	public virtual bool enoughActionPoints {
		get {
			return character.actionPoints.currentValue >= actionPointCost;
		}
	}

	public bool CanPerform (GridService gridService) {
		if (!enoughActionPoints) {
			return false;
		}

		targets = ValidTargetsInRange(gridService);
        return targets.Count >= requiredTargetCount;
	}

	public List<IReceiveAction> ValidTargetsInRange (GridService gridService) {
		var targetsInRange = TargetsInRange(gridService);
		return ValidateTargets(targetsInRange);
	}

	public List<IReceiveAction> TargetsInRange (GridService gridService) {
		var targetsInRange = new List<IReceiveAction>();
		List<Vector3> pointsToCheck = gridService.WorldPointsForAction(this);
		foreach (Vector3 pointToCheck in pointsToCheck) {
			var t = GetTargetsAtPoint(pointToCheck);
			if (t.Count > 0) {
				targetsInRange.AddRange(t);
			}
		}
		return targetsInRange;
	}

	List<IReceiveAction> GetTargetsAtPoint (Vector3 point) {
		float sphereRadius = GridService.gridUnit/2f;
		
		// get direction to move destination
		Vector3 start = character.go.transform.position; 
		start.y = sphereRadius;
		Vector3 direction = point - start;
		
		// get distance to move destination
		float dist = Vector3.Distance(start, point);
		RaycastHit[] hits = Physics.SphereCastAll(start, sphereRadius, direction, dist);
		
		var actionTargets = new List<IReceiveAction>();
		foreach (RaycastHit hit in hits) {
			var hitObj = hit.collider.gameObject;
			var gcs = hitObj.GetComponents<GameController>();

			foreach (GameController gc in gcs) {
				if (gc != null && gc.actionReceiver != null) {
					Debug.Log ("Action receiver is " + gc.actionReceiver);
					actionTargets.Add(gc.actionReceiver);
				}
			}
		}
		return actionTargets;
	}

    public List<IReceiveAction> ValidateTargets (List<IReceiveAction> _targets) {
        var validTargets = new List<IReceiveAction>();
        foreach (IReceiveAction target in _targets) {
            if (ValidTarget(target)) {
                validTargets.Add(target);
            }
        }

		return validTargets;
    }

    public bool ValidTarget (IReceiveAction target) {
        return true;
    }


	public void Perform () {
		character.EnterMode(controlMode);
		character.actionPoints.Decrement(actionPointCost);
		foreach (IReceiveAction target in targets) {
			target.ReceiveAction(this);
		}
	}

}
