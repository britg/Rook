using UnityEngine;
using System.Collections;

public abstract class Character : IReceiveAction {

    public GameObject go { get; set; }

    public abstract CharacterAlignment alignment { get; }

	public CharacterAttribute hitPoints { get; set; }
	public CharacterAttribute actionPoints { get; set; }
	public CharacterAttribute armorRating { get; set; }
	public CharacterAttribute attackRating { get; set; }
	public CharacterAttribute detectRange { get; set; }

    CharacterAction _action;
	public CharacterAction action {
        get {
            return _action;
        }
        set {
            _action = value;
            _action.owner = this;
        }
    }

    public virtual void ResetActionPoints () {
        actionPoints.SetToMax();
    }

	public bool InDetectionRange (float distance) {
		return distance <= (float)detectRange.maxValue;
	}
}
