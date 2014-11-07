using UnityEngine;
using System.Collections;

public abstract class AgentTurnProcessor : ActionProcessor {

    public override string ActionType {
        get {
            return "AgentTurnAction";
        }
    }

	public override void Process (GameAction action) {
		Agent agent = action.agent;
	}

}
