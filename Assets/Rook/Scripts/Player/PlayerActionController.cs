using UnityEngine;
using System.Collections;

public class PlayerActionController : GameController {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarriorActionButtonPressed () {
		StartAction(player.warriorAction);
    }

	public void WarriorActionButtonPointerEnter () {
		gridService.HighlightAction(player.warriorAction);
	}

	public void WarriorActionButtonPointerExit () {
		gridService.ResetColors();
	}

	public void StartAction (CharacterAction action) {
		if (action.requiresSelection) {
			PromptSelection(action);
		} else {
			PerformAction(action);
		}
	}

	public void PromptSelection (CharacterAction action) {
		Debug.Log ("Prompting selection for action " + action);
		playerController.EnterMode(PlayerControlMode.GridSelect);
		// prompt the selection and get the callback
	}

	public void PerformAction (CharacterAction action) {
		Debug.Log ("Performing action " + action);
		playerController.EnterMode (PlayerControlMode.Wait);
	}

}
