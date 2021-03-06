using UnityEngine;
using System.Collections;

public class AgentController : GameBehaviour {

	public virtual Agent agent { get; set; }
	public virtual AgentTurnProcessor agentTurnProcessor { get; set; }

	protected virtual void Register () {
		agentRegistry.Register(agent);
	}

	protected virtual void Unregister () {
		agentRegistry.Unregister(agent);
	}

	public virtual void TurnFinished () {
		actionQueue.Add(AgentTurnFinishedAction.Instance);
	}


}
