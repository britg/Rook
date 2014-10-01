using UnityEngine;
using System.Collections;

public class PlayerRotationAction : GameAction {

	public override int actionPointCost {
		get {
			return 1;
		}
	}

	public Vector3 aimPoint;

}
