using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridService {

	GridBuilder builder;
	FlatHexGrid<TileCell> grid;
	IMap3D<FlatHexPoint> map;

	public GridService (GridBuilder _builder) {
		builder = _builder;
		grid = builder.Grid;
		map = builder.Map;
	}

	public FlatHexPoint GridPointFromWorldPoint (Vector3 worldPoint) {
		return map[worldPoint];
	}

	public Vector3 WorldPointFromGridPoint (FlatHexPoint gridPoint) {
		return map[gridPoint];
	}

	public TileCell GridCellFromWorldPoint (Vector3 worldPoint) {
		FlatHexPoint gridPoint = GridPointFromWorldPoint(worldPoint);
		if (grid.Contains(gridPoint)) {
			return grid[gridPoint];
		} else {
			return null;
		}
	}

	public Vector3 NearestCellCenter (Vector3 worldPoint) {
        FlatHexPoint gridPoint = map[worldPoint];
        TileCell cell = grid[gridPoint];
        return cell.Center;
	}

	public void ResetMap (Vector3 playerPosition) {
		float cellWidth = builder.CellPrefab.Dimensions.x;
		float cellHeight = builder.CellPrefab.Dimensions.x/80*69;
		Vector2 cellDimensions = new Vector2(cellWidth, cellHeight);

		Rect screenRect = new Rect(-Screen.width/2, -Screen.height/2, Screen.width, Screen.height);

		map = new FlatHexMap(cellDimensions)
			.AnchorCellCenter()
			.WithWindow(screenRect)
			.Translate(playerPosition.x, playerPosition.z)
			.To3DXZ();
	}

	public void SetCellColorAt (Vector3 worldPoint, Color color) {
		TileCell cell = GridCellFromWorldPoint(worldPoint);
		SetCellColor(cell, color);
	}

	public void SetCellColor (TileCell cell, Color color) {
		cell.Color = color;
	}

	public void ClearHighlights () {

	}


}
