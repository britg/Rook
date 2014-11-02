using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionQueue {

	enum State {
		Idle,
		Processing
	}

	Queue queue = new Queue();
	GameAction currentAction;
	State state = State.Idle;

	public delegate void Callback ();

	Callback callback;

	bool isIdle {
		get {
			return state == State.Idle;
		}
	}

	bool isProcessing {
		get {
			return state == State.Processing;
		}
	}

	Dictionary<string, ActionProcessor> registry = new Dictionary<string, ActionProcessor>();

	public ActionQueue (Callback _callback) {
		callback = _callback;
	}

	public void Register (string actionType, ActionProcessor processor) {
		//Debug.Log("Adding " + actionType + " with processor " + processor);
		registry[actionType] = processor;
	}

	public void Add (GameAction action) {
        Debug.Log("Adding " + action);
		queue.Enqueue(action);

		if (isIdle) {
			state = State.Processing;
			Process();
		}
	}

	public void Continue () {
		currentAction = null;
		if (queue.Count < 1) {
			Idle();
			return;
		}
		Process();
	}

	void Process () {
		if (currentAction != null) {
			return;
		}

		if (queue.Count < 1) {
			Idle();
			return;
		}

		state = State.Processing;
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
		callback.Invoke();
		Continue();
	}

	void Idle () {
		Debug.Log ("Going idle...");
		state = State.Idle;
	}


}
