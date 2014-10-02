using UnityEngine;
using System.Collections;

public class EnemyController : GameController {

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

	void InitializeEnemy () {
		enemy = new Enemy();
		enemy.go = gameObject;
		enemy.actionPoints = new CharacterAttribute(seedValue: 3);
		enemy.detectRange = new CharacterAttribute(seedValue: 10);
		enemy.hitPoints = new CharacterAttribute(seedValue: 100);
		enemy.action = new SwordSwipeAction(from: 20, to: 30);
	}

    void Register () {
        turnController.RegisterEnemy(enemy);
		NotificationCenter.AddObserver(this, Notifications.ActionFinished);
    }

	void Unregister () {
		turnController.UnregisterEnemy(enemy);
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
