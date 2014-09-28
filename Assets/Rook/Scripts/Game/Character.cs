using UnityEngine;
using System.Collections;

public abstract class Character {

    public abstract CharacterAlignment alignment { get; }

	public CharacterAttribute hitPoints { get; set; }
	public CharacterAttribute actionPoints { get; set; }
	public CharacterAttribute armorRating { get; set; }
	public CharacterAttribute attackRating { get; set; }

	public CharacterAction action { get; set; }

    public virtual void ResetActionPoints () {
        actionPoints.SetToMax();
    }
}
