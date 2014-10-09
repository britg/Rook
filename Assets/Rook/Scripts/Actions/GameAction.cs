using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public abstract class GameAction {

	public virtual string ActionType {
		get {
			return "GameAction";
		}
	}

	public virtual string Name {
		get {
			return "Game Action";
		}
	}

	public virtual Character character { get; set; }
	public virtual Color color {
		get {
			return character.color;
		}
	}

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

	public virtual List<FlatHexPoint> gridPoints { get; set; }

    public virtual bool hasEnoughActionPoints {
        get {
            return character.actionPoints.currentValue >= actionPointCost;
        }
    }

    public virtual bool exclusive {
        get {
            return false;
        }
    }

	public virtual void SpendActionPoints () {
		character.actionPoints.Decrement(actionPointCost);
	}

	public virtual void Done () {

	}

	public override string ToString () {
		return string.Format ("[GameAction: {0}/{1}]", ActionType, Name);
	}

}
