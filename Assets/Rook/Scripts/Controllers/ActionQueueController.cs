using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionQueueController : GameController {

	Queue queue = new Queue();
	GameAction currentAction;

	Dictionary<string, ActionProcessor> registry = new Dictionary<string, ActionProcessor>();

	public void Register (string actionType, ActionProcessor processor) {
		//Debug.Log("Adding " + actionType + " with processor " + processor);
		registry[actionType] = processor;
	}

	public void Add (GameAction action) {
        Debug.Log("Adding " + action);
		queue.Enqueue(action);
		Process();
	}

	void Process () {
		if (currentAction != null) {
			return;
		}

		if (queue.Count < 1) {
			Debug.Log ("Action queue empty");
			return;
		}

		currentAction = (GameAction)queue.Dequeue();
		string actionType = currentAction.ActionType;

		if (registry.ContainsKey(actionType)) {
			Debug.Log ("Processing a new action: " + currentAction);
			ActionProcessor processorForType = registry[actionType];
			processorForType.Process(currentAction);
		} else {
			Debug.Log ("A processor was not found for " + currentAction);
			Continue();
		}
	}

	public void CompletedAction () {
        Debug.Log("Finishing " + currentAction);
		currentAction.Done();
		PostActionFinished();
		Continue();
	}

	void PostActionFinished () {
		NotificationCenter.PostNotification(this, Notifications.ActionFinished);
	}

	public void Continue () {
		currentAction = null;
		Process();
	}
	
}
