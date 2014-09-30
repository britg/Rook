using UnityEngine;
using System.Collections;

public class ActionQueueController : GameController {

	Queue queue = new Queue();
	CharacterAction currentAction;

	public void Add (CharacterAction action) {
		queue.Enqueue(action);
		Process();
	}

	void Process () {
		if (currentAction != null) {
			return;
		}

		if (queue.Count < 1) {
			return ;
		}

		currentAction = (CharacterAction)queue.Dequeue();
		StartAction();
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
			Invoke ("FinishAction", 1f);
		} else {
			Debug.Log("No valid targets!");
		}
	}
	
	public void FinishAction () {
		PostActionFinished();
		playerController.DefaultMode();
		currentAction = null;
		Process();
	}
	
}
