using UnityEngine;
using System.Collections;
using Vectrosity;

public class PlayerMoveView : View {

    public float lineWidth;
    public Color lineColor;
    VectorLine line;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateLine () {
        Vector3 start = Vector3.zero;
        Vector3 end = Vector3.zero;
        line = VectorLine.SetLine3D(lineColor, new Vector3[2] { start, end });
        line.SetWidth(lineWidth, 0);
        line.Draw3DAuto();
    }

    void DrawMove (PlayerMove playerMove) {
        if (line == null) {
            CreateLine();
        }


    }
}
