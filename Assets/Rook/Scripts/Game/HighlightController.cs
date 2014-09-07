using UnityEngine;
using System.Collections;
using ProBuilder2.Common;

public class HighlightController : GameController {

    public GameObject highlightPrefab;

    GameObject highlightObj;
    Vector3 currentPosition;

    public void CurrentPosition (Vector3 pos) {
        currentPosition = pos;
    }

    void Start () {
    }

    void Update () {
    }

	void CreateHighlight () {
        highlightObj = ProBuilder.Instantiate(highlightPrefab, Vector3.zero, Quaternion.identity);
	}

    void DrawHighlight () {
		Vector3 newPos = GridPosition();
		highlightObj.transform.position = newPos;
    }

    Vector3 GridPosition () {
        return grid.NearestFaceW(currentPosition);
    }

}
