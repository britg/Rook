using UnityEngine;
using System.Collections;

public class PlacePlayerAction : GameAction {

	public override string ActionType {
		get {
			return "MapAction";
		}
	}
	
	public override string Name {
		get {
			return "Place Player";
		}
	}

}
