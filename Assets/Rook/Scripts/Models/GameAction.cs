using UnityEngine;
using System.Collections;

public abstract class GameAction {

	public virtual int actionPointCost {
		get {
			return 1;
		}
	}

	public virtual bool requiresSelection {
		get {
			return false;
		}
	}

	public virtual void Done () {
	}

}
