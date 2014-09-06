using UnityEngine;
using System.Collections;

public class EnemyController : GameController {

    public Enemy enemy;

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
            return;
        }

        Vector3 playerPos = playerObj.transform.position;
        Vector3 playerDir = playerPos - transform.position;
        Vector3 oneHexTowardsPlayer = transform.position + playerDir.normalized * (3f/2f*grid.radius);
        Vector3 nearestHex = grid.NearestFaceW(oneHexTowardsPlayer);

        if (nearestHex.Equals(playerObj.transform.position)) {
            Attack();
        } else {
            MoveToPosition(nearestHex);
        }
    }

    bool DetectPlayerInRange () {
        return true;
    }

    void Attack () {
        Debug.Log("Attacking player!");
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
