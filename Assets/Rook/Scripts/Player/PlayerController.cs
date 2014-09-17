using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public Player player;

    public bool isMoving {
        get {
            return player.isMoving;
        }
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
	}

}
