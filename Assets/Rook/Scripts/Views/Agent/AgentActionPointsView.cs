using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AgentActionPointsView : AgentTextView {

	AgentAttribute actionPoints {
		get {
			return agent.actionPoints;
		}
	}

	protected override void Display () {
		textDisplay.text = string.Format("AP: {0}", actionPoints.currentValue);
	}
}
