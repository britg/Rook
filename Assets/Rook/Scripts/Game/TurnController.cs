using UnityEngine;
using System.Collections;

public class TurnController : MonoBehaviour {

    bool playerTurn = false;
    public bool PlayerTurn {
        get { return playerTurn; }
    }

	void Start () {
        StartTurn();
	}

    public void EndTurn () {
        playerTurn = false;
        // stub out enemies taking their turn
        Invoke("StartTurn", 2f);
    }

    public void StartTurn () {
        playerTurn = true;
    }
	
}
