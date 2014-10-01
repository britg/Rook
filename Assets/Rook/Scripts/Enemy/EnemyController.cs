using UnityEngine;
using System.Collections;

public class EnemyController : GameController {

    public Enemy enemy;
    Vector3 playerPos {
		get {
			return playerObj.transform.position;
		}
	}
    Vector3 playerDir {
		get {
			return (playerPos - transform.position).normalized;
		}
	}

	public override IReceiveAction actionReceiver {
		get {
			return enemy;
		}
	}

	void Awake () {
		InitializeEnemy();
	}

	void Start () {
        Register();
        SnapToGrid();
	}

	void InitializeEnemy () {
		enemy = new Enemy();
		enemy.go = gameObject;
		enemy.actionPoints = new CharacterAttribute(seedValue: 3);
		enemy.detectRange = new CharacterAttribute(seedValue: 10);
		enemy.hitPoints = new CharacterAttribute(seedValue: 100);
		enemy.action = new SwordSwipeAction(from: 20, to: 30);
	}

    void Register () {
        turnController.RegisterEnemy(gameObject);
		NotificationCenter.AddObserver(this, Notifications.ActionFinished);
    }

	void Unregister () {
		turnController.UnregisterEnemy(gameObject);
	}

    void TakeTurn () {
    	TakeAction();
    }

    void TakeAction () {

        if (enemy.Detect(playerObj)) {
            EnterCombat();
        } else {
			ExitCombat();
            TurnFinished();
            return;
        }

        Vector3 oneHexTowardsPlayer = transform.position + playerDir * GridService.gridUnit;
        Vector3 nearestHex = gridService.NearestCellCenter(oneHexTowardsPlayer);

        if (nearestHex.Equals(playerObj.transform.position)) {
            Attack();
        } else {
            MoveToPosition(nearestHex);
			enemy.actionPoints.Decrement();
        }
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
        SnapToGrid();
        turnController.EnemyTurnFinished(gameObject);
    }

    void EnterCombat () {
        combatService.EnterCombat(gameObject);
    }

	void ExitCombat () {
		combatService.ExitCombat(gameObject);
	}

	void OnActionFinished () {
		DieIfDead();
	}

	void DieIfDead () {
		if (enemy.dead) {
			Unregister();
			Destroy (gameObject);
		}
	}
}
