﻿using UnityEngine;
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
		Invoke ("Process", 0f);
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
		string actionType = currentAction.ActionType;

		if (registry.ContainsKey(actionType)) {
			Debug.Log ("Processing a new action: " + actionType);
			ActionProcessor processorForType = registry[actionType];
			processorForType.Process(currentAction);
		} else {
			Debug.Log ("A processor was not found for type " + actionType);
			Continue();
		}
	}

	public void CompletedAction () {
		currentAction.Done();
		PostActionFinished();
		Continue();
	}

	public void Continue () {
		currentAction = null;
		Process();
	}
	
}
