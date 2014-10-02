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

	public new CombatService combatService = new CombatService();

    void Start () {
		Invoke("StartTurn", 1f);
		NotificationCenter.AddObserver(this, Notifications.ActionFinished);
    }

    public void RegisterEnemy (Enemy enemy) {
        enemies.Add(enemy);
    }

	public void UnregisterEnemy (Enemy enemy) {
		enemies.Remove(enemy);
	}

	public void EndTurnButtonPressed () {
		QueueEndTurn();
	}

	void QueueEndTurn () {
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
//            enemy.SendMessage("TakeTurn", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void EnemyTurnFinished (Enemy enemy) {
        enemiesTakingTurn.Remove(enemy);

        if (enemiesTakingTurn.Count < 1) {
            EndEnemyTurn();
        }
    }

    public void EndEnemyTurn () {
        StartTurn();
    }

    public void StartTurn () {
        currentTurn++;
        playerTurn = true;
        NotificationCenter.PostNotification(this, Notifications.PlayerTurn);
    }

	void OnActionFinished () {
		Debug.Log ("Action finished");
		DetermineEndOfTurn();
	}

	void DetermineEndOfTurn () {
		if (player.actionPoints.currentValue < 1) {
			Debug.Log ("No more action points left!");
		}
	}

}
