using UnityEngine;
using System.Collections;

public class TurnController : MonoBehaviour {

    public float turnDelay = 0.5f;
    public int currentTurn = 1;

    bool playerTurn = false;
    public bool PlayerTurn {
        get { return playerTurn; }
    }

    public bool inCombat = false;
    public bool InCombat {
        get { return inCombat; }
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
        currentTurn++;
        playerTurn = true;
        NotificationCenter.PostNotification(this, Notifications.PlayerTurn);
    }
	
}
