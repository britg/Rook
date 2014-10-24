using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AgentTextView : View {

	Agent _agent;
	public Agent agent {
		get {
			if (_agent == null) {
				_agent = GetComponent<AgentController>().agent;
			}
			return _agent;
		}
	}
	
	public GameObject textDisplayPrefab;
	public Vector3 offset = Vector3.zero;
	protected Text textDisplay;
	
	bool Ready {
		get {
			return textDisplay != null && agent != null;
		}
	}
	
	void Start () {
		CreateDisplay();
	}
	
	void Update () {
		if (Ready) {
			Display();
			Follow();
		}
	}
	
	void CreateDisplay () {
		var newObj = (GameObject)Instantiate(textDisplayPrefab);
		newObj.transform.SetParent(canvasObj.transform);
		textDisplay = newObj.GetComponent<Text>();
	}
	
	protected virtual void Display () {
		
	}
	
	void Follow () {
		var screenPos = Camera.main.WorldToScreenPoint(agent.position);
		textDisplay.transform.position = screenPos + offset;
	}
	
	void OnDestroy () {
		if (textDisplay != null) {
			Destroy (textDisplay.gameObject);
		}
	}
}
