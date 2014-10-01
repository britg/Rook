using UnityEngine;
using System.Collections;

public abstract class ActionProcessor : GameController {

	public virtual string ActionType {
		get {
			return "GameAction";
		}
	}

	void Start () {
		Register();
	}

	protected virtual void Register () {
		actionQueueController.Register(ActionType, this);
	}

	public abstract void Process (GameAction action);

	public virtual void DoneProcessing () {
		actionQueueController.CompletedAction();
	}

}
