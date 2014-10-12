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

    CharacterAttribute hitpoints {
        get {
            return character.hitPoints;
        }
    }

    public GameObject textDisplayPrefab;
    Text textDisplay;

    public string format;


    void Start () {
        CreateDisplay();
    }

    void Update () {
        if (textDisplay != null && character != null) {
            if (character.dead) {
                Destroy(textDisplay.gameObject);
                return;
            }
            textDisplay.text = string.Format("HP: {0}", hitpoints.currentValue);
            textDisplay.transform.position = Camera.main.WorldToScreenPoint(character.go.transform.position);
        }
    }

    void CreateDisplay () {
        var newObj = (GameObject)Instantiate(textDisplayPrefab);
        newObj.transform.SetParent(canvasObj.transform);
        textDisplay = newObj.GetComponent<Text>();
    }

}
