using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class PlayerController : GameBehaviour {

	public int seedHitPoints;
	public int seedActionPoints;
	public override Player player { get; set; }

	public override IReceiveAction actionReceiver {
		get {
			return player;
		}
	}

    public bool isMoving {
        get {
            return player.isMoving;
        }
    }

    GameObject _warriorObj;
    GameObject warriorObj {
        get {
            if (_warriorObj == null) {
                _warriorObj = transform.FindChild("Warrior").gameObject;
            }
            return _warriorObj;
        }
    }

    GameObject _thiefObj;
    GameObject thiefObj {
        get {
            if (_thiefObj == null) {
                _thiefObj = transform.FindChild("Thief").gameObject;
            }
            return _thiefObj;
        }
    }

    GameObject _mageObj;
    GameObject mageObj {
        get {
            if (_mageObj == null) {
                _mageObj = transform.FindChild("Mage").gameObject;
            }
            return _mageObj;
        }
    }


	void Awake () {
		InitializePlayer();
	}

	void InitializePlayer () {
		player = new Player(gameObject);
		player.hitPoints = new AgentAttribute(seedValue: seedHitPoints);
		player.actionPoints = new AgentAttribute(seedValue: seedActionPoints);
        player.warrior.go = warriorObj;
		player.AssignWarriorAction(new AttackAction(min: 30, max: 50, crit: 10));
		player.Init();
	}

    void Start () {
		NotificationCenter.AddObserver(this, Notifications.PlayerTurn);
    }

	public void EnterMode (PlayerControlMode mode) {
		player.EnterMode(mode);
		NotificationCenter.PostNotification(this, Notifications.EnterControlMode);
	}

	public void DefaultMode () {
		EnterMode(PlayerControlMode.Move);
	}

	void OnPlayerTurn () {
		DefaultMode();
		ResetActionPoints();
	}

	void ResetActionPoints () {
		player.ResetActionPoints();
	}
}
