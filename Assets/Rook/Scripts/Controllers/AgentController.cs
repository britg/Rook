using UnityEngine;
using System.Collections;

public abstract class AgentController : GameController {

	public virtual Agent agent { get; set; }

	protected virtual void Register () {
		agentRegistry.Register(agent);
	}

}
