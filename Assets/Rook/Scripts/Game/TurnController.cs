using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnController : MonoBehaviour {

	public int currentTurn = 1;
    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> enemiesTakingTurn = new List<GameObject>();

    bool playerTurn = false;
    public bool PlayerTurn {
        get { return playerTurn; }
    }

    public bool inCombat = false;
    public bool InCombat {
        get { return inCombat; }
    }

    void Start () {
		Invoke("StartTurn", 1f);
    }

    public void RegisterEnemy (GameObject enemy) {
        enemies.Add(enemy);
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

    public void EnemyTurnFinished (GameObject enemy) {
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

    public void EnterCombat () {
        if (inCombat) {
            return;
        }

        Debug.Log("Entering combat!");
        inCombat = true;
    }

}
