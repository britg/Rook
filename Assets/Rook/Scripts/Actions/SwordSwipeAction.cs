using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class  SwordSwipeAction : CharacterAction {

	public SwordSwipeAction (int from, int to) {
		name = "Sword Swipe";
		gridPoints = new List<FlatHexPoint>{ new FlatHexPoint(0, 1) };
		_actionPointCost = 1;
		controlMode = PlayerControlMode.Wait;
		damage = new ValueRange(from: from, to: to);
	}

	public void Process () {
		Debug.Log ("Sword swipe action processing");
	}

}
