using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridHighlightController : GameController {

	public Color defaultColor;
	public Color highlightColor;
	TileCell currentCell;
	
	void Start () {
    }

    void Update () {
    }

	public void MouseOverGridAt (Vector3 point) {
		point.y = transform.position.y;
		TileCell cell = gridService.GridCellFromWorldPoint(point);
		
		if (currentCell != null) {
			gridService.SetCellColor(currentCell, defaultColor);
		}
		
		if (cell == null) {
			return;
		}
		
		currentCell = cell;
		gridService.SetCellColor(currentCell, highlightColor);
	}
	
	void DrawHighlight () {
	}
	
}
