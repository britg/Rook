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

        Vector3 oneHexTowardsPlayer = transform.position + playerDir.normalized * (3f/2f*grid.radius);
        Vector3 nearestHex = grid.NearestFaceW(oneHexTowardsPlayer);

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
        float hexDist = playerDistance / (3f / 2f * grid.radius);
        return hexDist <= (float)enemy.DetectRange;
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
