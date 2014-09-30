using UnityEngine;
using System.Collections;

public abstract class GameAction {

	public virtual bool requiresSelection {
		get {
			return false;
		}
	}

}
