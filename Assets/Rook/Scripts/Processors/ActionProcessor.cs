using UnityEngine;
using System.Collections;

public abstract class ActionProcessor : GameBehaviour {

	public virtual string ActionType {
		get {
			return "GameAction";
		}
	}

	void Start () {
		Register();
	}

	protected virtual void Register () {
		actionQueue.Register(ActionType, this);
	}

	public abstract void Process (GameAction action);

	public virtual void DoneProcessing () {
		actionQueue.CompletedAction();
	}

}
