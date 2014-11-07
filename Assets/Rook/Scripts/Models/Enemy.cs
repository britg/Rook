using UnityEngine;
using System.Collections;

public class Enemy : Character {

	public Enemy (GameObject _go) : base(_go) {

	}

	public override void TakeTurn () {
		// Reset action points
		// Detect player?
		// start of melee action
		// if next to player attack
		// 
//		if (inCombat) {
//			RotateToTarget(playerPos);
//			if (gridService.Adjacent(enemyPos, playerPos)) {
//				Attack();
//			} else {
//				PathfindToTarget(player);
//			}
//			
//		} else {
//			Idle();
//			return;
//		}
		controller.TurnFinished();
	}

	void Attack () {

	}

	void PathfindToTarget (Agent target) {

	}

	void Idle () {

	}

}
