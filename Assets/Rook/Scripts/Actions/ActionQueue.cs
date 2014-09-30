using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionQueue {

	public delegate void FinishedCallback();

	static Queue queue = new Queue();
	public static FinishedCallback finishedCallback;

	public static void Add (CharacterAction action) {
		queue.Enqueue(action);
	}

	public static void Perform (FinishedCallback onFinish) {
		finishedCallback = onFinish;
	}

	public static void Done () {
		finishedCallback();
	}

}
