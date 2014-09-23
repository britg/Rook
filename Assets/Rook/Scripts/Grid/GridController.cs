using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridController : GameController {

    public Color defaultColor;
    public Color highlightColor;

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

    public void HighlightCellAt (Vector3 point) {
        point.y = transform.position.y;
		TileCell cell = gridService.GridCellFromWorldPoint(point);

        if (currentCell != null) {
            currentCell.Color = defaultColor;
        }

		if (cell == null) {
			return;
		}

        currentCell = cell;
        currentCell.Color = highlightColor;
    }

	void OnPlayerTurn () {
		gridService.ResetMap(playerObj.transform.position);
	}

}
