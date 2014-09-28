using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

[System.Serializable]
public class CharacterAction  {

    public Character character;

	public string name;
	public List<FlatHexPoint> gridPoints;
	public int actionPointCost;
	public PlayerControlMode controlMode;

	public bool requiresSelection {
		get {
			return controlMode == PlayerControlMode.GridSelect;
		}
	}

}
