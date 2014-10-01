using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridController : GameController { 

	public new GridService gridService;

	void Awake () {
        GridBuilder builder = GetComponent<GridBuilder>();
		gridService = new GridService(builder, playerObj.transform);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
