using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridController : GameController {

    public Color defaultColor;
    public Color highlightColor;

    FlatHexGrid<TileCell> grid;
    IMap3D<FlatHexPoint> map;

    TileCell currentCell;

	// Use this for initialization
	void Start () {
        FlatHexTileGridBuilder builder = GetComponent<FlatHexTileGridBuilder>();
        grid = builder.Grid;
        map = builder.Map;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void HighlightCellAt (Vector3 point) {
        point.y = transform.position.y;
        FlatHexPoint gridPoint = map[point];
        TileCell cell = grid[gridPoint];

        if (currentCell != null) {
            currentCell.Color = defaultColor;
        }

        currentCell = cell;
        currentCell.Color = highlightColor;
    }

    public Vector3 NearestCellCenter (Vector3 worldPoint) {
        FlatHexPoint gridPoint = map[worldPoint];
        TileCell cell = grid[gridPoint];
        return cell.Center;
    }
}
namespace System.Runtime.CompilerServices {
    public class ExtensionAttribute : Attribute { }
}