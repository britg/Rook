using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

[System.Serializable]
public class CharacterAction  {

    public Character owner;
    public List<IReceiveAction> targets;
	public PlayerControlMode controlMode;

	public string name;
	public List<FlatHexPoint> gridPoints;
	public int actionPointCost;
	public ValueRange damage;
	public int requiredTargetCount = 1;

	public virtual bool enoughActionPoints {
		get {
			return owner.actionPoints.currentValue >= actionPointCost;
		}
	}
    

	public bool requiresSelection {
		get {
			return controlMode == PlayerControlMode.GridSelect;
		}
	}

    public void ValidateTargets (List<IReceiveAction> _targets) {
        targets = new List<IReceiveAction>();
        foreach (IReceiveAction target in _targets) {
            if (ValidTarget(target)) {
                targets.Add(target);
            }
        }
    }

    public bool ValidTarget (IReceiveAction target) {
        return true;
    }

	public bool CanPerform (GridService gridService) {
		if (!enoughActionPoints) {
			return false;
		}

		var targetsInRange = owner.TargetsInRange(gridService);
		ValidateTargets(targetsInRange);
        return targets.Count >= requiredTargetCount;
	}

	public void Perform () {
		owner.actionPoints.Decrement(actionPointCost);
	}

}
