using UnityEngine;
using System.Collections;

public class PlaceAgentsAction : GameAction {

	public override string ActionType {
		get {
			return "MapAction";
		}
	}

	public override string Name {
		get {
			return "PlaceAgents";
		}
	}
	
}

