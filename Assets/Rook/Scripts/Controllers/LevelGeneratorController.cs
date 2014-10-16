using UnityEngine;
using System.Collections;
using MapService;

public class LevelGeneratorController : GameController {

	public GameObject wallTile;
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
		map.Instantiate(wallTile);
	}
}
