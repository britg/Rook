using UnityEngine;
using System.Collections;

public class EnemyController : GameController {

    public Enemy enemy;
    Vector3 playerPos;
    Vector3 playerDir;
    float playerDistance;

	// Use this for initialization
	void Start () {
        Register();
        SnapToGrid();
	}

    void Register () {
        turnController.RegisterEnemy(gameObject);
    }

    void TakeTurn () {
        TakeAction();
        SnapToGrid();
    }

    void TakeAction () {

        bool inRange = DetectPlayerInRange();

        if (inRange) {
            EnterCombat();
        } else {
            TurnFinished();
            return;
        }

        Vector3 oneHexTowardsPlayer = transform.position + playerDir.normalized * (1.5f);
        Vector3 nearestHex = gridController.NearestCellCenter(oneHexTowardsPlayer);

        if (nearestHex.Equals(playerObj.transform.position)) {
            Attack();
        } else {
            MoveToPosition(nearestHex);
        }
    }

    bool DetectPlayerInRange () {
        playerPos = playerObj.transform.position;
        playerDir = playerPos - transform.position;
        playerDistance = Vector3.Distance(playerPos, transform.position);
        return playerDistance <= (float)enemy.DetectRange;
    }

    void Attack () {
        Debug.Log("Attacking player!");
        TurnFinished();
    }

    void MoveToPosition (Vector3 pos) {
        iTween.MoveTo(gameObject, iTween.Hash("position", pos,
                                              "time", 0.2f,
                                              "oncomplete", "DoneMoving"));
    }

    void DoneMoving () {
        TurnFinished();
    }

    void TurnFinished () {
        turnController.EnemyTurnFinished(gameObject);
    }

    void EnterCombat () {
        turnController.EnterCombat();
    }
}
