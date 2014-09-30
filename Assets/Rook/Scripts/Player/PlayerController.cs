using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class PlayerController : MonoBehaviour {

	public int seedHitPoints;
	public int seedActionPoints;
    public Player player;

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
        player.go = gameObject;
		player.hitPoints = new CharacterAttribute(seedValue: seedHitPoints);
		player.actionPoints = new CharacterAttribute(seedValue: seedActionPoints);
        player.warrior.go = warriorObj;
		player.AssignWarriorAction(new SwordSwipeAction());
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
