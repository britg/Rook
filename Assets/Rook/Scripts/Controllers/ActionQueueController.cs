using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionQueueController : GameBehaviour {

	ActionQueue _actionQueue;
	public override ActionQueue actionQueue {
		get {
			if (_actionQueue == null) {
				_actionQueue = new ActionQueue(AfterActionCallback);
			}
			return _actionQueue;
		}
	}

	void AfterActionCallback () {
		Post(Notifications.ActionFinished);
	}

}
