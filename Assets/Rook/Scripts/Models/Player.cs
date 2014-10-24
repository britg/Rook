using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : Character {

    public override CharacterAlignment alignment {
        get {
            return CharacterAlignment.Player;
        }
    }

	Warrior _warrior;
	public Warrior warrior {
		get {
			if (_warrior == null) {
				_warrior = new Warrior(GameObject.Find ("Warrior"));
			}
			return _warrior;
		}
	}

	Thief _thief;
	public Thief thief {
		get {
			if (_thief == null) {
				_thief = new Thief(GameObject.Find ("Thief"));
			}
			return _thief;
		}
	}

	Mage _mage;
	public Mage mage {
		get {
			if (_mage == null) {
				_mage = new Mage(GameObject.Find ("Mage"));
			}
			return _mage;
		}
	}

    public GameAction warriorAction {
        get {
            return warrior.action;
        }
    }

    public GameAction thiefAction {
        get {
            return thief.action;
        }
    }

    public GameAction mageAction {
        get {
            return mage.action;
        }
    }

    public bool isRotating {
        get {
            return controlMode == PlayerControlMode.Rotate;
        }
    }

    public bool isMoving {
        get {
            return controlMode == PlayerControlMode.Move;
        }
    }

	public bool canStartAction {
		get {
			return controlMode == PlayerControlMode.Move;
		}
	}

	public Player (GameObject _go) : base(_go) {
	}


	public void Init () {
		isPlayer = true;
		warrior.player = this;
		thief.player = this;
		mage.player = this;
	}

	public void AssignWarriorAction (GameAction action) {
        warrior.action = action;
	}

	public void AssignThiefAction (GameAction action) {

	}

	public void AssignMageAction (GameAction action) {

	}

}
