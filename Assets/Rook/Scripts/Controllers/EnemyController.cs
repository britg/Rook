using UnityEngine;
using System.Collections;

public class EnemyController : AgentController {

    public override Character character {
        get {
            return (Character)enemy;
        }
        set {

        }
    }

    public Enemy enemy;

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

	protected virtual void InitializeEnemy () {
		enemy = new Enemy();
		enemy.go = gameObject;
		enemy.actionPoints = new CharacterAttribute(seedValue: 3);
		enemy.detectRange = new CharacterAttribute(seedValue: 10);
		enemy.hitPoints = new CharacterAttribute(seedValue: 100);
		enemy.action = new AttackAction(min: 15, max: 40, crit: 10);
	}

    void Register () {
		enemyRegistry.Register(enemy);
		Observe(Notifications.ActionFinished);
    }

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
