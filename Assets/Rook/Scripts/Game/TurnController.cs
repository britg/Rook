using UnityEngine;
using System.Collections;

public class TurnController : MonoBehaviour {

    public float turnDelay = 0.5f;

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
        Invoke("StartTurn", turnDelay);
    }

    public void StartTurn () {
        playerTurn = true;
    }
	
}
