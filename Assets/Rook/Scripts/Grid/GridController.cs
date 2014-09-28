using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridController : GameController { 

	public new GridService gridService;

	// Use this for initialization
	void Start () {
        GridBuilder builder = GetComponent<GridBuilder>();
		gridService = new GridService(builder, playerObj.transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
