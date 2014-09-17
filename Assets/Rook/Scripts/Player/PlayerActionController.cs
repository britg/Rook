using UnityEngine;
using System.Collections;

public class PlayerActionController : GameController {

	bool warriorActionActive {
		get {
			return player.warriorActionActive;
		}
	}

	Action currentAction;

	// Use this for initialization
	void Start () {
		NotificationCenter.AddObserver(this, Notifications.EnterControlMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarriorActionButtonPressed () {
		if (warriorActionActive) {
			playerController.DefaultMode();
		} else {
        	playerController.EnterMode(PlayerControlMode.WarriorAction);
		}
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
		currentAction = player.warriorAction;
		tileSelectionController.PromptSelection(currentAction.tileSelection);
	}

	void OnTileSelectionMade (Notification n) {
		Debug.Log ("Tile selection made " + n);
	}

}
