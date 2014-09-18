﻿using UnityEngine;
using System.Collections;
using ProBuilder2.Common;

public class HighlightController : GameController {

	TileHighlightView highlightView;

    Vector3 currentPosition;
	Vector3 gridPosition {
		get {
			return grid.NearestFaceW(currentPosition);
		}
	}

    public void CurrentPosition (Vector3 pos) {
        currentPosition = pos;
    }

    void Start () {
		highlightView = gameObject.GetComponent<TileHighlightView>();
    }

    void Update () {
		DrawHighlight();
    }

    void DrawHighlight () {
//		highlightView.HighlightTiles();
    }

    Vector3 GridPosition () {
        return grid.NearestFaceW(currentPosition);
    }

}
