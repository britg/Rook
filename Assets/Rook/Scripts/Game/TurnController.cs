using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnController : GameController {

	public int currentTurn = 1;
    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> enemiesTakingTurn = new List<GameObject>();

    bool playerTurn = false;
    public bool PlayerTurn {
        get { return playerTurn; }
    }

	public CombatService combatService = new CombatService();

    void Start () {
		Invoke("StartTurn", 1f);
		NotificationCenter.AddObserver(this, Notifications.ActionFinished);
    }

    public void RegisterEnemy (GameObject enemyObj) {
        enemies.Add(enemyObj);
    }

	public void UnregisterEnemy (GameObject enemyObj) {
		enemies.Remove(enemyObj);
	}

    public void EndTurn () {
        playerTurn = false;
        StartEnemyTurn();
    }

    void StartEnemyTurn () {
        enemiesTakingTurn = new List<GameObject>();
        foreach (GameObject enemy in enemies) {
            enemiesTakingTurn.Add(enemy);
            enemy.SendMessage("TakeTurn", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void EnemyTurnFinished (GameObject enemyObj) {
        enemiesTakingTurn.Remove(enemyObj);

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
