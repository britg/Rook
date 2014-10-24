using UnityEngine;
using System.Collections;

public class TurnService {

	public int currentTurn = 1;
	public bool isPlayerTurn = false;

	public void StartPlayerTurn () {
		currentTurn++;
		isPlayerTurn = true;
	}
}
