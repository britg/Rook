using UnityEngine;
using System.Collections;

public class PlayerActionController : GameController {

	bool warriorActionActive {
		get {
			return player.warriorActionActive;
		}
	}

	PlayerAction currentAction;

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

	public void WarriorActionButtonPointerEnter () {
		Debug.Log ("Warrior action button pointer enter");
		gridService.HighlightAction(player.warriorAction);
	}

	public void WarriorActionButtonPointerExit () {
		Debug.Log ("Warrior action button pointer exit");
		gridService.ResetColors();
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
		tileSelectionController.PromptSelectionForAction(currentAction, OnTileSelectionMade);
	}

	void OnTileSelectionMade (Vector2 selectedGridPoint) {
		Debug.Log ("Tile selection made " + selectedGridPoint);
		// get affected tiles from the action
		// raycast to affected game objects
		// apply the action's effects to the affected game objects
	}

}
