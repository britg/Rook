using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridHighlightController : GameController {

	TileCell currentCell;
	
	void Start () {
    }

    void Update () {
    }

	public void MouseOverGridAt (Vector3 point) {
		point.y = transform.position.y;
		TileCell cell = gridService.GridCellFromWorldPoint(point);
		
		if (currentCell != null) {
			gridService.SetCellColor(currentCell, GameColors.defaultCellColor);
		}
		
		if (cell == null) {
			return;
		}
		
		currentCell = cell;
		gridService.SetCellColor(currentCell, GameColors.cursorCellColor);
	}
	
	void DrawHighlight () {
	}
	
}
