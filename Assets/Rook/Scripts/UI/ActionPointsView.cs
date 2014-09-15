using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActionPointsView : View {

    Text text;

	int currentActionPoints {
		get {
			return player.actionPoints.currentValue;
		}
	}

    void Start () {
        text = GetComponent<Text>();
    }

    void Update () {
        text.text = "Action Points: " + currentActionPoints;
    }
  
}
