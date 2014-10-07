using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class GridService {

	public static float gridUnit = 1.91f;
	public static float rotationAngle = 60f;

	GridBuilder builder;
	FlatHexGrid<TileCell> grid;
	IMap3D<FlatHexPoint> map;

	List<TileCell> coloredCells = new List<TileCell>();

	Transform playerTransform;

	float playerRotation {
		get {
			return playerTransform.eulerAngles.y;
		}
	}

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

    public List<Vector3> WorldPointsForAction (GameAction action) {
        float referenceRotation = action.character.rotation;
        var worldPoints = new List<Vector3>();
		foreach (FlatHexPoint point in action.gridPoints) {
			var rotatedPoint = RotatedPoint(point, referenceRotation);
			worldPoints.Add(WorldPointFromGridPoint(rotatedPoint));
		}
        return worldPoints;
    }

	public void HighlightAction (GameAction action) {
		if (action.gridPoints == null) {
			return;
		}
		foreach (FlatHexPoint point in action.gridPoints) {
			HighlightRelativePoint(point, action.color, action.character.rotation);
		}
	}

	public void HighlightRelativePoint (FlatHexPoint point, Color color, float referenceRotation = 0f) {
		FlatHexPoint gridPoint = RotatedPoint(point, referenceRotation);
		TileCell cell = GridCellFromGridPoint(gridPoint);
		SetCellColor(cell, color);
	}

	FlatHexPoint RotatedPoint (FlatHexPoint point, float referenceRotation) {
		int rotationSlot = Mathf.RoundToInt(referenceRotation / 60f);
        //Debug.Log ("Rotation slot is " + rotationSlot);
        FlatHexPoint rotated = point;
		switch (rotationSlot) {
		case 1:
			rotated = point.Rotate300();
			break;
		case 2:
			rotated = point.Rotate240();
			break;
		case 3:
			rotated = point.Rotate180();
			break;
		case 4:
			rotated = point.Rotate120();
			break;
		case 5:
			rotated = point.Rotate60();
			break;
		}
		return rotated;
	}

}
