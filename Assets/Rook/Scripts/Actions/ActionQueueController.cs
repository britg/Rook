using UnityEngine;
using System.Collections;

public class ActionQueueController : GameController {

	Queue queue = new Queue();
	GameAction currentAction;

	public void Add (GameAction action) {

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

		currentAction = (GameAction)queue.Dequeue();
		StartAction();
	}

	void StartAction () {
		StartAction (currentAction);
	}
	
	public void StartAction (GameAction action) {
		PerformAction(action);
	}

	public void PerformAction (GameAction action) {
		Debug.Log ("Performing action " + action);
//		action.Perform();
		Invoke ("FinishAction", 1f);
	}
	
	public void FinishAction () {
		PostActionFinished();
//		playerController.DefaultMode();
		currentAction = null;
		Process();
	}
	
}
