using UnityEngine;
using System.Collections;

public class ValueRange {

	public int maxValue {get; set;}
	public int minValue {get; set; }
	public int rand {
		get {
			return RandomValue();
		}
	}

	public ValueRange (int from, int to) {
		minValue = from;
		maxValue = to;
	}

	public int RandomValue () {
		return Random.Range(minValue, maxValue);
	}

}
