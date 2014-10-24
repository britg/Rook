using UnityEngine;
using System.Collections;

public class AgentAttribute {

	public string name;
	
	public int maxValue {get; set;}
	public int minValue {get; set; }
	public int currentValue { get; set; }
	
	public AgentAttribute (int seedValue) {
		maxValue = seedValue;
		SetValue(seedValue);
	}
	
	public int SetValue (int newValue) {
		currentValue = (int)Mathf.Clamp((float)newValue, (float)minValue, (float)maxValue);
		return currentValue;
	}
	
	public int Decrement (int amount) {
		return SetValue (currentValue - amount);
	}
	
	public int Decrement () {
		return Decrement(1);
	}
	
	public void SetToMax () {
		currentValue = maxValue;
	}

}
