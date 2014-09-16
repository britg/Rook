using UnityEngine;
using System.Collections;

public class Attribute {

	public string name;

	public int maxValue {get; set;}
	public int minValue {get; set; }
	public int currentValue { get; set; }

	public Attribute (int seedValue) {
		maxValue = seedValue;
		SetValue(seedValue);
	}

	public int SetValue (int newValue) {
		currentValue = (int)Mathf.Clamp((float)newValue, (float)minValue, (float)maxValue);
		return currentValue;
	}

	public int RandomValue () {
		return Random.Range(minValue, maxValue);
	}

}
