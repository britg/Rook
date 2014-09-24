using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridController : GameController { 

	public GridService gridService;

    TileCell currentCell;

	// Use this for initialization
	void Start () {
        GridBuilder builder = GetComponent<GridBuilder>();
		gridService = new GridService(builder);
		NotificationCenter.AddObserver(this, Notifications.PlayerTurn);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPlayerTurn () {
		gridService.ResetMap(playerObj.transform.position);
	}

}
