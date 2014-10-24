using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnCountView : View {

    Text text;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (turnService != null) {
            string turnLabel = "";
            if (turnService.isPlayerTurn) {
                turnLabel += "Your Turn (" + player.controlMode + ")";
            } else {
                turnLabel += "Enemy Turn ";
            }
            
            text.text = turnLabel + turnService.currentTurn;
        }
	}
}
