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

	void Awake () {
		player.hitPoints = new CharacterAttribute(seedValue: seedHitPoints);
		player.actionPoints = new CharacterAttribute(seedValue: seedActionPoints);
	}

    void Start () {
		NotificationCenter.AddObserver(this, Notifications.PlayerTurn);
		InitializePlayer();
    }

	void InitializePlayer () {
		player.AssignWarriorAction(new SwordSwipeAction());
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
