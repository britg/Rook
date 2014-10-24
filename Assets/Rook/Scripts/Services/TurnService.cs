using UnityEngine;
using System.Collections;

public class TurnService {

	public int currentTurn = 0;
	public bool isPlayerTurn = false;

	public AgentRegistry agentRegistry;

	public void StartPlayerTurn () {
		currentTurn++;
		isPlayerTurn = true;
	}

	public void EndPlayerTurn () {
		isPlayerTurn = false;
	}

}
