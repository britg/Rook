using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyTurnProcessor : ActionProcessor {

    public override string ActionType {
        get {
            return "EnemyTurnAction";
        }
    }

    public Enemy enemy;

    Vector3 enemyPos {
        get {
            return enemy.go.transform.position;
        }
    }

    Vector3 playerPos {
        get {
            return playerObj.transform.position;
        }
    }
    Vector3 playerDir {
        get {
            return (playerPos - enemy.go.transform.position).normalized;
        }
    }

    public override void Process (GameAction action) {
        switch (action.Name) {
            case "Start":
                StartTurn((StartEnemyTurnAction)action);
                break;
            case "Continue":
                ContinueTurn((ContinueEnemyTurnAction)action);
                break;
            default:
                Debug.Log("Could not processes action " + action);
                break;
        }
    }

    void StartTurn (StartEnemyTurnAction startAction) {
        enemy = startAction.enemy;
        enemy.ResetActionPoints();
		if (enemy.inCombat) {
        	ContinueTurn();
		} else {
			EndTurn();
		}
    }

    public void ContinueTurn (ContinueEnemyTurnAction continueAction) {
        enemy = continueAction.enemy;
        ContinueTurn();
    }

    void ContinueTurn () {
        Debug.Log("Current action points available " + enemy.actionPoints.currentValue);
        if (enemy.actionPoints.currentValue > 0) {
            TakeAction();
        } else {
            EndTurn();
        }
    }

    void TakeAction () {
        

        if (enemy.inCombat) {
            RotateToTarget(playerPos);
            if (gridService.Adjacent(enemyPos, playerPos)) {
                Attack();
            } else {
                PathfindToTarget(player);
            }

        } else {
            Idle();
            return;
        }

    }

    void Idle () {
        EndTurn();
    }

    void RotateToTarget (Vector3 target) {
        enemy.RotateToTarget(target);
    }

    void Attack () {
        Debug.Log("Attacking player!");
        actionQueueController.Add(enemy.action);
        QueueContinue();
        DoneProcessing();
    }

    void PathfindToTarget (Character target) {
        var pathfindingService = new PathfindingService((Character)enemy, target, gridService);
        var moveAction = pathfindingService.GetMoveAction();
        if (!moveAction.valid) {
            Debug.Log("No valid path to player!!! ending turn");
            EndTurn();
            DoneProcessing();
            return;
        }

        actionQueueController.Add(moveAction);
        QueueContinue();
        DoneProcessing();
    }

    void QueueContinue () {
        var continueAction = new ContinueEnemyTurnAction(enemy);
        actionQueueController.Add(continueAction);
    }

    void EnemyActionDone () {
        enemy.SnapToGrid(gridService);
        QueueContinue();
        DoneProcessing();
    }

    void EndTurn () {
        enemy.SnapToGrid(gridService);
        turnController.EnemyTurnFinished(enemy);
        DoneProcessing();
    }

}
