﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackProcessor : ActionProcessor {
	
	public override string ActionType {
		get {
			return "AttackAction";
		}
	}
	
	AttackAction attackAction;
	List<IReceiveAction> targets;

	public override void Process (GameAction action) {
		attackAction = (AttackAction)action;
		targets = ValidTargetsInRange();
		// Get valid targets at the gridPoints of the action
		// if there are any valid targets, attack them and then use the action points necessary
		// if there are no valid targets show a warning
	}

	public List<IReceiveAction> ValidTargetsInRange () {
		var targetsInRange = TargetsInRange();
		return ValidateTargets(targetsInRange);
	}
	
	public List<IReceiveAction> TargetsInRange () {
		var targetsInRange = new List<IReceiveAction>();
		List<Vector3> pointsToCheck = gridService.WorldPointsForAction(attackAction);
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
		Vector3 start = attackAction.character.go.transform.position; 
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
	
}