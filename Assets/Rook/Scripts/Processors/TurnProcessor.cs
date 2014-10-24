using UnityEngine;
using System.Collections;

public class TurnProcessor : ActionProcessor {

	public TurnService turnService = new TurnService();

	public override string ActionType {
		get {
			return "TurnAction";
		}
	}

	public override void Process (GameAction action) {

	}

}
