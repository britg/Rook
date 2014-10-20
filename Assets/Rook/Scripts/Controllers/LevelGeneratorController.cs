using UnityEngine;
using System.Collections;
using MapService;

public class LevelGeneratorController : GameController {

	public GameObject wallTilePrefab;
	public GameObject enemyPrefab;
	Map map;

	// Use this for initialization
	void Start () {
//		GenerateLevel();
		Invoke ("GenerateLevel", 1f);
		Invoke ("InstantiateMap", 2f);
		Invoke ("PlaceAgents", 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateLevel () {
		map = new Map(player);
		map.Generate();
	}

	void InstantiateMap () {
		map.Instantiate(wallTilePrefab);
	}

	void PlaceAgents () {
        map.PlacePlayer();
		map.PlaceEnemies(enemyPrefab);
	}
}
