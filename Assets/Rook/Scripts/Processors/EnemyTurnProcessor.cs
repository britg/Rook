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
			Debug.Log ("Could not processes action " + action);
			break;
		}
	}

	void StartTurn (StartEnemyTurnAction startAction) {
		enemy = startAction.enemy;
		enemy.ResetActionPoints();
		QueueContinue();
		DoneProcessing();
	}

	public void ContinueTurn (ContinueEnemyTurnAction continueAction) {
		enemy = continueAction.enemy;
		if (enemy.actionPoints.currentValue > 0) {
			TakeAction();
		} else {
			TurnFinished();
		}
	}
	
	void TakeAction () {
		
		if (enemy.Detect(playerObj)) {
			EnterCombat();
		} else {
			ExitCombat();
			TurnFinished();
			return;
		}
		
		if (gridService.Adjacent(enemyPos, playerPos)) {
			RotateToTarget(playerPos);
			Attack();
		} else {
			PathfindToTarget(playerPos);
		}
	}

	void RotateToTarget (Vector3 target) {

	}

	void Attack () {
		Debug.Log("Attacking player!");
		enemy.actionPoints.Decrement();
		actionQueueController.Add (enemy.action);
		Invoke ("EnemyActionDone", 0.5f);
	}

	void PathfindToTarget (Vector3 target) {
		var pathfindingService = new PathfindingService((Character)enemy, target, gridService);
		var waypoints = pathfindingService.GetPath();

		var moveAction = new MoveAction((Character)enemy);
		foreach (Vector3 waypoint in waypoints) {
			moveAction.AddWaypoint(waypoint);
		}

		actionQueueController.Add (moveAction);
		QueueContinue();
		DoneProcessing();
	}
	
	void MoveToPosition (Vector3 pos) {
		var moveAction = new MoveAction((Character)enemy);
		moveAction.AddWaypoint(pos);

		if (moveAction.waypoints.Count < 1) {
			Debug.Log ("No valid moves for enemy");
			DoneProcessing();
			return;
		}

		actionQueueController.Add (moveAction);
		QueueContinue();
		DoneProcessing();
//		enemy.actionPoints.Decrement();
//		iTween.MoveTo(enemy.go, iTween.Hash("position", pos,
//		                                      "time", 0.2f,
//		                                      "oncomplete", "EnemyActionDone",
//		                                      "oncompletetarget", gameObject));
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
	
	void TurnFinished () {
		enemy.SnapToGrid(gridService);
		turnController.EnemyTurnFinished(enemy);
		DoneProcessing();
	}
	
	void EnterCombat () {
		combatService.EnterCombat(enemy.go);
	}
	
	void ExitCombat () {
		combatService.ExitCombat(enemy.go);
	}
	
}
