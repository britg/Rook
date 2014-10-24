using UnityEngine;
using System.Collections;

public class AgentHitpointsView : AgentTextView {

	AgentAttribute hitpoints {
		get {
			return agent.hitPoints;
		}
	}
	
	
	protected override void Display () {
		textDisplay.text = string.Format("HP: {0}", hitpoints.currentValue);
	}
}
