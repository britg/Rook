using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionQueueController : GameController {

	Queue queue = new Queue();
	GameAction currentAction;

	Dictionary<string, ActionProcessor> registry = new Dictionary<string, ActionProcessor>();

	public void Register (string actionType, ActionProcessor processor) {
		Debug.Log("Adding " + actionType + " with processor " + processor);
		registry[actionType] = processor;
	}

	public void Add (GameAction action) {
		queue.Enqueue(action);
		Process();
	}

	void Process () {
		if (currentAction != null) {
			Debug.Log ("Still processing current action " + currentAction);
			return;
		}

		if (queue.Count < 1) {
			Debug.Log ("Action queue empty");
			return;
		}

		currentAction = (GameAction)queue.Dequeue();
		string actionType = currentAction.GetType().ToString();
		ActionProcessor processorForType = registry[actionType];

		if (processorForType != null) {
			processorForType.Process(currentAction);
		} else {
			Continue();
		}
	}

	public void CompletedAction () {
		PostActionFinished();
		Continue();
	}

	public void Continue () {
//		playerController.DefaultMode();
		currentAction = null;
		Process();
	}
	
}
