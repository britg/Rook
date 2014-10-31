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
		actionQueueController.Add(new GenerateMapAction());
		actionQueueController.Add(new PlacePlayerAction());
		actionQueueController.Add(new PlaceEnemiesAction());
		actionQueueController.Add(new GameAction("AgentRegistry", "Refresh"));
		actionQueueController.Add(new GameAction("CombatService", "Refresh"));
		actionQueueController.Add(new StartTurnAction());
	}
}
