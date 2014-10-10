using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class PlayerRotationView : View {

	PlayerRotationAction action;

	Transform aimProxy {
		get {
			return action.aimProxy;
		}
	}

	Vector3 aimPoint {
		get {
			return action.aimPoint;
		}
	}

	public void Init (PlayerRotationAction _action) {
		action = _action;
	}

	public void Display () {
		gridService.ResetColors();

		var warriorPoint = new FlatHexPoint(0, 1);
		var thiefPoint = new FlatHexPoint(1, -1);
		var magePoint = new FlatHexPoint(-1, 0);

		aimProxy.LookAt(aimPoint);
		Vector3 angles = aimProxy.eulerAngles;
		float angle = angles.y;
		float remain = angle % GridService.rotationAngle;
		float nearest = 0f;
		if (remain > GridService.rotationAngle / 2f) {
			nearest = Mathf.Ceil(angle / GridService.rotationAngle) * GridService.rotationAngle;
		} else {
			nearest = Mathf.Floor(angle / GridService.rotationAngle) * GridService.rotationAngle;
		}
		
		gridService.HighlightRelativePoint(warriorPoint, GameColors.warriorCellColor, nearest);
		gridService.HighlightRelativePoint(thiefPoint, GameColors.thiefCellColor, nearest);
		gridService.HighlightRelativePoint(magePoint, GameColors.mageCellColor, nearest);
	}

	public void Clear () {
		gridService.ResetColors();
	}
}
