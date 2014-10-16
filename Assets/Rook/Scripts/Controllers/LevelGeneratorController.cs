using UnityEngine;
using System.Collections;
using MapService;

public class LevelGeneratorController : GameController {

	public GameObject wallTilePrefab;
	public GameObject enemyPrefab;
	Map map;

	// Use this for initialization
	void Start () {
		GenerateLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateLevel () {
		map = new Map();
		map.Generate();
		map.Instantiate(wallTilePrefab);
		map.PlaceEnemies(enemyPrefab);
	}
}
