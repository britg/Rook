using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerActionController : GameController {

	CharacterAction currentAction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarriorActionButtonPressed () {
		currentAction = player.warriorAction;
		Invoke ("StartAction", 0.1f);
    }

	public void WarriorActionButtonPointerEnter () {
		gridService.HighlightAction(player.warriorAction);
	}

	public void WarriorActionButtonPointerExit () {
		gridService.ResetColors();
	}

	void StartAction () {
		StartAction (currentAction);
	}

	public void StartAction (CharacterAction action) {
		if (!player.canStartAction) {
			return;
		}

		if (action.requiresSelection) {
			PromptSelection(action);
		} else {
			PerformAction(action);
		}
	}

	public void PromptSelection (CharacterAction action) {
		Debug.Log ("Prompting selection for action " + action);
		// prompt the selection and get the callback
	}

	public void PerformAction (CharacterAction action) {
		Debug.Log ("Performing action " + action);

        if (action.CanPerform(gridService)) {
			playerController.EnterMode (action.controlMode);
			action.Perform();
			Invoke("FinishAction", 1f);
        } else {
            Debug.Log("No valid targets!");
		}

	}

	public void FinishAction () {
		PostActionFinished();
        playerController.DefaultMode();
	}

}
