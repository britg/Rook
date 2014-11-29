using UnityEngine;
using System.Collections;

public abstract class ActionProcessor : GameBehaviour {

	public delegate void ActionIdHandler(GameAction action);

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

	protected virtual void Register (GameAction.ActionId id, ActionIdHandler handler) {
		actionQueue.Register (id, handler);
	}

	public abstract void Process (GameAction action);

	public virtual void DoneProcessing () {
		actionQueue.CompletedAction();
	}

}
