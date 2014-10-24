using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Vectrosity;

public class MoveView : View {

	VectorLine line;

	public float lineWidth;
	public Color lineColor;

	public MoveAction moveAction;

	public Image confirmationPanel;

	// Use this for initialization
	void Start () {
		HideConfirmation();
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

	public void Redraw () {
		if (line == null) {
			CreateLine();
		}
		
		if (moveAction.waypoints.Count < 1) {
			return;
		}
		
		line.Resize(moveAction.waypoints.Count + 1);
		line.points3[0] = moveAction.agentPosition;
		
		for (int i = 0; i < moveAction.waypoints.Count; i++) {
			Vector3 p = moveAction.waypoints[i];
			p.y += 0.5f; // hover amount
			line.points3[i + 1] = p;
		}
	}

	public void Reset () {
		VectorLine.Destroy(ref line);
	}

	public void DisplayConfirmation () {
		confirmationPanel.gameObject.SetActive(true);
		confirmationPanel.gameObject.transform.position = Camera.main.WorldToScreenPoint(moveAction.lastWaypoint);
	}

	void HideConfirmation () {
		confirmationPanel.gameObject.SetActive(false);
	}

	public void ConfirmMove () {
		HideConfirmation();
		actionQueueController.Add (moveAction);
	}

	public void CancelMove () {
		HideConfirmation();
		moveAction.Reset();
	}
}
