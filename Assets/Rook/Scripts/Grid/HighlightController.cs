using UnityEngine;
using System.Collections;
using ProBuilder2.Common;

public class HighlightController : GameController {

    Vector3 currentPosition;
	TileHighlightView highlightView;

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
		Vector3 pos = grid.NearestFaceHO(currentPosition);
		Debug.Log(pos);
//		highlightView.HighlightTiles();
    }

    Vector3 GridPosition () {
        return grid.NearestFaceW(currentPosition);
    }

}
