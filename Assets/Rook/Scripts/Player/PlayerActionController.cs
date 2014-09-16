using UnityEngine;
using System.Collections;

public class PlayerActionController : GameController {

	// Use this for initialization
	void Start () {
		NotificationCenter.AddObserver(this, Notifications.EnterControlMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarriorActionButtonPressed () {
        playerController.EnterMode(PlayerControlMode.WarriorAction);
    }

	public void OnEnterControlMode () {
		BeginActionForControlMode(player.controlMode);
	}

	void BeginActionForControlMode (PlayerControlMode mode) {
		switch (mode) {
		case PlayerControlMode.WarriorAction:
			BeginWarriorAction();
			break;
		}
	}

	void BeginWarriorAction () {

	}
}
