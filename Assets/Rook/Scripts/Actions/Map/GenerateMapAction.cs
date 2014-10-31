using UnityEngine;
using System.Collections;

public class GenerateMapAction : GameAction {
	
	public override string ActionType {
		get {
			return "MapAction";
		}
	}
	
	public override string Name {
		get {
			return "Generate Map";
		}
	}
	
}
