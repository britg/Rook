using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

[System.Serializable]
public class CharacterAction  {

    public Character owner;
    public List<IReceiveAction> targets;

	public string name;
	public List<FlatHexPoint> gridPoints;
	public int actionPointCost;
	public PlayerControlMode controlMode;

    public virtual bool isValid {
        get {
            return false;
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
        return false;
    }

}
