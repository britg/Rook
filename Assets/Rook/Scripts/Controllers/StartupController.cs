using UnityEngine;
using System.Collections;

public class StartupController : GameBehaviour {

	void Start () {
		// Startup flow
		// 1. Generate Map
		// 2. Instantiate Map Elements (walls)
		// 3. Place Enemies
		// 4. Place Player
		// 5. Start Player turn

		StartCoroutine(StartUp());
	}

	IEnumerator StartUp () {
		yield return 0;
		actionQueue.Add(new GenerateMapAction());
		actionQueue.Add(new PlacePlayerAction());
		actionQueue.Add(new PlaceEnemiesAction());
		actionQueue.Add(new GameAction("AgentRegistry", "Refresh"));
		actionQueue.Add(new GameAction("CombatService", "Refresh"));
		actionQueue.Add(new StartTurnAction());
	}
}
