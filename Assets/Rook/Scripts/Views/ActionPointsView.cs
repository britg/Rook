using UnityEngine;
using System.Collections;

public class ActionPointsView : CharacterTextView {

	CharacterAttribute actionPoints {
		get {
			return character.actionPoints;
		}
	}

	protected override void Display () {
		textDisplay.text = string.Format("AP: {0}", actionPoints.currentValue);
	}

}
