﻿using UnityEngine;
using System.Collections;

public class EnemyController : AgentController {

    public Character character {
        get {
            return (Character)enemy;
        }
        set {

        }
    }

    public override Agent agent {
        get {
            return (Agent)enemy;
        }
        set {

        }
    }

	public override IReceiveAction actionReceiver {
		get {
			return enemy;
		}
	}

    public Enemy enemy;

	void Awake () {
		InitializeEnemy();
	}

	void Start () {
        Register();
        SnapToGrid();
	}

	protected virtual void InitializeEnemy () {
		enemy = new Enemy(gameObject);
		enemy.actionPoints = new CharacterAttribute(seedValue: 3);
		enemy.detectRange = new CharacterAttribute(seedValue: 10);
		enemy.hitPoints = new CharacterAttribute(seedValue: 100);
		enemy.action = new AttackAction(min: 15, max: 40, crit: 10);
	}

//    void Register () {
//		enemyRegistry.Register(enemy);
//		Observe(Notifications.ActionFinished);
//    }

	void Unregister () {
		enemyRegistry.Unregister(enemy);
	}

	void OnActionFinished () {
		DieIfDead();
	}
	
	void DieIfDead () {
		if (enemy.dead) {
            combatService.ExitCombat((Character)enemy);
			Unregister();
			Destroy (gameObject);
		}
	}

}
