using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectionService  {

	static List<string> nonBlockingTags = new List<string>{ "Player", "Grid", "Floor" };

	Agent detector;
	Agent target;

	Vector3 detectorPos {
		get {
			return detector.go.transform.position;
		}
	}

	Vector3 targetPos {
		get {
			return target.go.transform.position;
		}
	}

	float range {
		get {
			return detector.detectRange.currentValue;
		}
	}

	float distance {
		get {
			return Vector3.Distance(detectorPos, targetPos);
		}
	}

	Vector3 direction {
		get {
			return targetPos - detectorPos;
		}
	}

	public bool inRange {
		get {
			return distance <= range;
		}
	}

	public DetectionService (Agent _detector, Agent _target) {
		detector = _detector;
		target = _target;
	}

	public bool Detect () {
		if (!inRange) {
			return false;
		}

		return TargetVisible();
	}

	public bool TargetVisible () {
		float sphereRadius = GridService.gridUnit/2f;
		RaycastHit[] hits = Physics.SphereCastAll(detectorPos, sphereRadius, direction, distance);
		foreach (RaycastHit hit in hits) {
			if (hit.collider.gameObject != detector.go && !nonBlockingTags.Contains(hit.collider.gameObject.tag)) {
				return false;
			}
		}
		
		return true;
	}
	
}
