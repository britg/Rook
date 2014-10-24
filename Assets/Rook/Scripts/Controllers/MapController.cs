using UnityEngine;
using System.Collections;
using MapService;

public class MapController : GameBehaviour {

	public GameObject wallTilePrefab;
	public GameObject enemyPrefab;
	public override Map map { get; set; }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
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

	public void PlaceEnemies () {
		map.PlaceEnemies(enemyPrefab);
	}

	public void PlacePlayer () {
        map.PlacePlayer();
	}
}
