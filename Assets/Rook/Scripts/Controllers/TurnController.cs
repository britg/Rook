using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnController : GameController {

	public int currentTurn = 1;

    bool playerTurn = false;
    public new bool PlayerTurn {
        get { return playerTurn; }
    }

	public void EndTurnButtonPressed () {
		QueueEndPlayerTurn();
	}

	public void ResetButtonPressed () {
		Application.LoadLevel(Application.loadedLevel);
	}

	void QueueEndPlayerTurn () {
		var endTurnAction = new EndTurnAction();
		actionQueueController.Add(endTurnAction);
	}

    public void EndTurn () {
        playerTurn = false;
        StartEnemiesTurn();
    }

    void StartEnemiesTurn () {
		enemyRegistry.SeedTurn();
		ContinueEnemiesTurn();
    }

	void ContinueEnemiesTurn () {
		var enemy = enemyRegistry.NextEnemyTakingTurn();
		if (enemy != null) {
			QueueStartEnemyTurn(enemy);
		} else {
			QueueStartPlayerTurn();
		}
	}

	void QueueStartEnemyTurn (Enemy enemy) {
		var startEnemyTurnAction = new StartEnemyTurnAction(enemy);
		actionQueueController.Add(startEnemyTurnAction);
	}

    public void EnemyTurnFinished (Enemy enemy) {
		enemyRegistry.EnemyDoneWithTurn(enemy);
		ContinueEnemiesTurn();
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

}
