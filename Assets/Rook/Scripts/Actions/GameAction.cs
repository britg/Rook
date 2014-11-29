using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class GameAction {

	public enum ActionId {

		GenerateMap,
		PlacePlayer,
		PlaceAgents,

		AgentRegistryRefresh,
		CombatServiceRefresh,

		StartPlayerTurn,
		EndPlayerTurn,

	}

	public GameAction () {

	}

	public GameAction (string actionType, string name) {
		_actionType = actionType;
		_name = name;
	}

	string _actionType = "GameAction";
	public virtual string ActionType {
		get {
			return _actionType;
		}
	}

	string _name = "ActionName";
	public virtual string Name {
		get {
			return _name;
		}
	}

	public virtual ActionId id { get; set; }

	public virtual Agent agent { get; set; }

	public virtual Color color {
		get {
			return agent.color;
		}
	}

	public virtual float referenceRotation {
		get {
			return agent.rotation;
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
            return agent.actionPoints.currentValue >= actionPointCost;
        }
    }

    public virtual bool exclusive {
        get {
            return false;
        }
    }

	public virtual void SpendActionPoints () {
		agent.actionPoints.Decrement(actionPointCost);
	}

	public virtual void Done () {

	}

	public override string ToString () {
		return string.Format ("[GameAction: {0}/{1}]", ActionType, Name);
	}

}
