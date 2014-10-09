using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnController : GameController {

	public int currentTurn = 1;
    List<Enemy> enemies = new List<Enemy>();
	List<Enemy> enemiesTakingTurn = new List<Enemy>();

    bool playerTurn = false;
    public new bool PlayerTurn {
        get { return playerTurn; }
    }
	public new CombatService combatService;
	
    void Start () {
		combatService = new CombatService(player);
		QueueStartPlayerTurn();
		NotificationCenter.AddObserver(this, Notifications.ActionFinished);
    }

    public void RegisterEnemy (Enemy enemy) {
        enemies.Add(enemy);
    }

	public void UnregisterEnemy (Enemy enemy) {
		enemies.Remove(enemy);
	}

	public void EndTurnButtonPressed () {
		QueueEndPlayerTurn();
	}

	void QueueEndPlayerTurn () {
		var endTurnAction = new EndTurnAction();
		actionQueueController.Add(endTurnAction);
	}

    public void EndTurn () {
        playerTurn = false;
        StartEnemyTurn();
    }

    void StartEnemyTurn () {
        enemiesTakingTurn = new List<Enemy>();
        foreach (Enemy enemy in enemies) {
            enemiesTakingTurn.Add(enemy);
			var startEnemyTurnAction = new StartEnemyTurnAction(enemy);
			actionQueueController.Add (startEnemyTurnAction);
        }
    }

    public void EnemyTurnFinished (Enemy enemy) {
        enemiesTakingTurn.Remove(enemy);
    }

	void QueueStartPlayerTurn () {
		var startTurnAction = new StartTurnAction();
		actionQueueController.Add(startTurnAction);
	}

    public void StartTurn () {
        currentTurn++;
        playerTurn = true;
        NotificationCenter.PostNotification(this, Notifications.PlayerTurn);
    }

	void OnActionFinished () {
		if (playerTurn) {
			DetermineEndOfPlayerTurn();
		} else {
			DetermineStartOfPlayerTurn();
		}
	}

	void DetermineEndOfPlayerTurn () {
		if (player.actionPoints.currentValue < 1) {
			Debug.Log ("No more action points left!");
		}
	}

	void DetermineStartOfPlayerTurn() {
		Debug.Log ("Enemies taking turn: " + enemiesTakingTurn.Count);
		if (enemiesTakingTurn.Count < 1) {
			Debug.Log ("End of enemies turn");
			QueueStartPlayerTurn();
		}
	}

}
