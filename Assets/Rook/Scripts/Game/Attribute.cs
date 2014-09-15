using UnityEngine;
using System.Collections;

public class Attribute {

	public string name;

	public int maxValue {get; set;}
	public int currentValue { get; set; }

	public Attribute (int seedValue) {
		maxValue = seedValue;
		currentValue = seedValue;
	}

}
