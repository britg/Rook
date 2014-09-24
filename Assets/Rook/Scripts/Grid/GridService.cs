using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class GridService {

	GridBuilder builder;
	FlatHexGrid<TileCell> grid;
	IMap3D<FlatHexPoint> map;

	List<TileCell> coloredCells = new List<TileCell>();

	Transform playerTransform;

	public GridService (GridBuilder _builder, Transform _playerTransform) {
		builder = _builder;
		grid = builder.Grid;
		map = builder.Map;
		playerTransform = _playerTransform;
	}

	public FlatHexPoint GridPointFromWorldPoint (Vector3 worldPoint) {
		return map[worldPoint];
	}

	public Vector3 WorldPointFromGridPoint (FlatHexPoint gridPoint) {
		return map[gridPoint];
	}

	public TileCell GridCellFromWorldPoint (Vector3 worldPoint) {
		FlatHexPoint gridPoint = GridPointFromWorldPoint(worldPoint);
		return GridCellFromGridPoint(gridPoint);
	}

	public TileCell GridCellFromGridPoint (FlatHexPoint gridPoint) {
		if (grid.Contains(gridPoint)) {
			return grid[gridPoint];
		} else {
			return null;
		}
	}

	public Vector3 NearestCellCenter (Vector3 worldPoint) {
        TileCell cell = GridCellFromWorldPoint(worldPoint);
		if (cell == null) {
			return worldPoint;
		}
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
		coloredCells.Add(cell);
	}

	public void ResetColors () {
		foreach (TileCell cell in coloredCells) {
			ResetCellColor(cell);
		}
		coloredCells = new List<TileCell>();
	}

	public void ResetCellColor (TileCell cell) {
		cell.Color = GameColors.defaultCellColor;
	}

	public void HighlightAction (PlayerAction action) {
		foreach (FlatHexPoint point in action.gridPoints) {
			Vector3 worldPoint = WorldPointFromGridPoint(point);
			Vector3 rotated = playerTransform.TransformPoint(worldPoint);
			FlatHexPoint gridPoint = GridPointFromWorldPoint(rotated);
			TileCell cell = GridCellFromGridPoint(gridPoint);
			SetCellColor(cell, GameColors.warriorCellColor);
		}
	}

}
