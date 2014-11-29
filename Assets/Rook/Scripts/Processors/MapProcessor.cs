using UnityEngine;
using System.Collections;
using MapService;

public class MapProcessor : ActionProcessor {
	
	public override string ActionType {
		get {
			return "MapAction";
		}
	}
	
	StartTurnAction action;

	public GameObject wallTilePrefab;
	public GameObject agentPrefab;
	public override Map map { get; set; }
	
	public override void Process (GameAction action) {

		if (action.Name == "PlaceAgents") {
			PlaceAgents();
		}

		switch (action.Name) {
		case "Generate Map":
			Bootstrap();
			break;
		case "Place Player":
			PlacePlayer();
			break;
		}
		DoneProcessing();
	}

	public void Bootstrap () {
		GenerateMap();
		InstantiateMap();
	}

	public void GenerateMap () {
		map = new Map(player);
		map.Generate();
	}

	void InstantiateMap () {
		map.Instantiate(wallTilePrefab);
	}

	public void PlacePlayer () {
        map.PlacePlayer();
	}

	void PlaceAgents () {
		map.PlaceAgents(agentPrefab);
	}

}
