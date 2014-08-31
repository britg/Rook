using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnCountUI : MonoBehaviour {

    public TurnController turnController;

    Text text;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (turnController != null) {
            text.text = "Turn: " + turnController.currentTurn;
        }
	}
}
