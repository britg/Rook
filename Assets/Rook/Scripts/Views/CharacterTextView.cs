using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterTextView : View {

    Character _character;
    public Character character {
        get {
            if (_character == null) {
                _character = GetComponent<NPCController>().character;
            }
            return _character;
        }
    }

    public GameObject textDisplayPrefab;
	public Vector3 offset = Vector3.zero;
    protected Text textDisplay;

	bool Ready {
		get {
			return textDisplay != null && character != null;
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
		var screenPos = Camera.main.WorldToScreenPoint(character.go.transform.position);
		textDisplay.transform.position = screenPos + offset;
	}

	void OnDestroy () {
        if (textDisplay != null) {
		    Destroy (textDisplay.gameObject);
        }
	}

}
