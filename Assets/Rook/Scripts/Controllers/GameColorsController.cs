using UnityEngine;
using System.Collections;

public class GameColorsController : MonoBehaviour {

	public GameColors colors;

	// Use this for initialization
	void Awake () {
		GameColors.instance = colors;
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
