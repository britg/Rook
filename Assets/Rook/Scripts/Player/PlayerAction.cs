using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

[System.Serializable]
public class PlayerAction  {

	public PlayerCharacterType playerCharacterType;

	public string name;
	public List<FlatHexPoint> gridPoints;
	public int actionPointCost;

}
