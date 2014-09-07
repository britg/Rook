using UnityEngine;
using System.Collections;

public class HighlightController : GameController {

    public GameObject highlightPrefab;

    GameObject highlightObj;
    Vector3 currentPosition;

    public void CurrentPosition (Vector3 pos) {
        currentPosition = pos;
    }

    void Start () {
        highlightObj = (GameObject)Instantiate(highlightPrefab);
    }

    void Update () {
        DrawHighlight();
    }

    void DrawHighlight () {
        highlightObj.transform.position = GridPosition();
    }

    Vector3 GridPosition () {
        return grid.NearestFaceW(currentPosition);
    }

}
