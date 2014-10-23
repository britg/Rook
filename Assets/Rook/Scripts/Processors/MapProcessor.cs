using UnityEngine;
using System.Collections;

public class MapProcessor : ActionProcessor {
	
	public override string ActionType {
		get {
			return "MapAction";
		}
	}
	
	StartTurnAction action;
	
	public override void Process (GameAction action) {
		switch (action.Name) {
		case "Generate Map":
			GenerateMap();
			break;
		case "Place Player":
			PlacePlayer();
			break;
		case "Place Enemies":
			PlaceEnemies();
			break;

		}
		DoneProcessing();
	}

	void GenerateMap () {
		mapController.Bootstrap();
	}

	void PlacePlayer () {
		mapController.PlacePlayer();
	}

	void PlaceEnemies () {
		mapController.PlaceEnemies();
	}
	
}
