using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnCountView : View {

    public TurnController turnController;

    Text text;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (turnController != null) {
            string turnLabel = "";
            if (turnController.PlayerTurn) {
                turnLabel += "Your Turn ";
            } else {
                turnLabel += "Enemy Turn ";
            }
            
            text.text = turnLabel + turnController.currentTurn;
        }
	}
}
