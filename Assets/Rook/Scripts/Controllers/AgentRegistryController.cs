using UnityEngine;
using System.Collections;

public class AgentRegistryController : GameController {
	
	public AgentRegistry agentRegistry { get; set; }
	
	void Awake () {
		agentRegistry = new AgentRegistry();
	}
	
}
