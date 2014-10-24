using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AgentRegistry {

    public List<Agent> agents = new List<Agent>();
	List<Agent> agentsTakingTurn = new List<Agent>();

    public void Register (Agent agent) {
        agents.Add(agent);
    }

	public void Unregister (Agent agent) {
		agents.Remove(agent);
	}

	public void SeedTurns () {
		agentsTakingTurn = new List<Agent>();
		agentsTakingTurn.AddRange(agents);
	}

	public Agent NextAgentTakingTurn () {
		return agentsTakingTurn.FirstOrDefault();;
	}

	public void AgentDoneWithTurn (Agent agent) {
		agentsTakingTurn.Remove (agent);
	}
}
