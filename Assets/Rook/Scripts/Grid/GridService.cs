using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridService {

	GridBuilder builder;
	FlatHexGrid<TileCell> grid;
	IMap3D<FlatHexPoint> map;

	public GridService (GridBuilder _builder) {
		Debug.Log (_builder.Map.GetType());
		builder = _builder;
		grid = builder.Grid;
		map = builder.Map;
	}

	public GridService (FlatHexGrid<TileCell> _grid, IMap3D<FlatHexPoint> _map) {
		grid = _grid;
		map = _map;
	}

	public FlatHexPoint GridPointFromWorldPoint (Vector3 worldPoint) {
		return map[worldPoint];
	}

	public Vector3 WorldPointFromGridPoint (FlatHexPoint gridPoint) {
		return map[gridPoint];
	}

	public TileCell GridCellFromWorldPoint (Vector3 worldPoint) {
		FlatHexPoint gridPoint = GridPointFromWorldPoint(worldPoint);
		return grid[gridPoint];
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
	
}
