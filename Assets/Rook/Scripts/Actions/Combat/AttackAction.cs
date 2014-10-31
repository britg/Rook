using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class AttackAction : GameAction {
	
	public override string ActionType {
		get {
			return "AttackAction";
		}
	}
	
	public override string Name {
		get {
			return "Attack Action";
		}
	}
	
	public ValueRange damageRange;
	public int critChance;
	
	public AttackAction (int min, int max, int crit) {
		damageRange = new ValueRange(from: min, to: max);
		critChance = crit;
		gridPoints = new List<FlatHexPoint>(){ new FlatHexPoint(0, 1) };
	}
	
}
