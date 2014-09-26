using UnityEngine;
using System.Collections;

public abstract class Character {

	public CharacterAttribute hitPoints { get; set; }
	public CharacterAttribute actionPoints { get; set; }
	public CharacterAttribute armorRating { get; set; }
	public CharacterAttribute attackRating { get; set; }

}
